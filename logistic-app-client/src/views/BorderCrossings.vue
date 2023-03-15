<template>
    <div class="list">
        <h1 class="title">Пункты пропуска</h1>
        <input class="field__search form-control form-control-sm" type="text" placeholder="Поиск" v-model="search">        
        <button class="btn btn_icon btn-sm btn-secondary new__btn"  v-on:click.prevent="newItem"><i>&#43;</i><span>Добавить</span></button>
        <Loader v-if="loading"/>
        <ul class="items-list" v-else-if="searchItems.length">
            <BorderCrossing
                v-for="(item, i) of searchItems" :key="item.id"
                v-bind:item="item" 
                v-bind:index="i"
                @remove-item="removeItem"
                @get-item="getItem"
            />
        </ul>
        <p v-else>Список пуст</p>
        <div v-if="Form" class="modal">
            <form id="From" class="modal__form" @submit.prevent="onSubmit">           
                <input v-if="item.id" v-model="item.id" type="hidden">
                <div class="form-row">
                  <div class="col form-group">
                    <label for="brand">Название</label>
                    <input class="form-control" name="brand" required v-model="item.name" type="text">
                  </div>
                </div>
                <div v-if="item.location" class="form-row">
                  <div class="col form-group">
                    <label for="number">Локация</label>
                    <input class="form-control" name="number" v-model="item.location" type="text" readonly>
                  </div>
                </div>
                <input class="btn btn-primary" type="submit" value="Сохранить">
                <button class="modal__form__close" v-on:click.prevent="closeModal"><svg xmlns="http://www.w3.org/2000/svg" version="1" viewBox="0 0 24 24"><path d="M13 12l5-5-1-1-5 5-5-5-1 1 5 5-5 5 1 1 5-5 5 5 1-1z"></path></svg></button>
            </form>
        </div>
    </div>
</template>

<script>
import Loader from '@/components/Loader'
import BorderCrossing from '@/components/BorderCrossing'
import {Encoder} from '@/components/Encoder.js'
export default {
    data(){
        return {
            ItemsList:[],
            loading: true,
            Form:false,
            item:{id:null,name:null,location:null},
            search:""
        }
    },
    computed:{
        searchItems(){
            if(this.search.length){
                return this.ItemsList.filter(c => c.name.toLowerCase().startsWith(this.search.toLowerCase()))
            }else{
                return this.ItemsList
            }
        }
    },
    methods:{
        async removeItem(id){
            await fetch('https://localhost:5001/api/bordercrossings/'+id, { 
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            this.ItemsList = this.ItemsList.filter(c => c.id !== id)
        },
        async getItems(){
            await fetch('https://localhost:5001/api/bordercrossings/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.ItemsList = json                
                this.loading = false
            })
        },
        async getItem(id){
            await fetch('https://localhost:5001/api/bordercrossings/'+id,{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.item = json;
            }).finally(()=>this.openModal())
        },
        newItem(){
            this.item = {id:null,name:null,location:null};
            this.openModal()
        },
        openModal(){
            this.Form = true;
        },
        closeModal(){
            this.Form = false;
            this.item = {id:null,name:null,location:null};
        },
        async onSubmit(){
            await Encoder.EncodeAddress(this.item.name).then(c => this.item.location = c)
            if(this.item.id){                
                await fetch('https://localhost:5001/api/bordercrossings/'+this.item.id, 
                { 
                    method: 'PUT',
                    body: JSON.stringify(this.item),
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                    }
                })
                .finally(() => {                    
                    this.getItems() 
                    this.closeModal()
                })
            }else{
                await fetch('https://localhost:5001/api/bordercrossings/', 
                { 
                    method: 'POST',
                    body: JSON.stringify(this.item),
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                    }
                })
                .then(response => response.json())
                .finally(() => {                    
                    this.getItems() 
                    this.closeModal()
                })
            }
            
        }
    },
    async mounted(){
        this.getItems()
    },
    components:{
        Loader, BorderCrossing
    } 
}
</script>

<style lang="scss">
  
.list {
  
  .new__btn {
    margin-bottom: 8px;
  }
  
  .field__search {
    margin-bottom: 1.2rem;
  }
  
  .title {
    margin-bottom: 1.5rem;
  }
}
.modal {
  position: absolute;
  top: 20%;
  left: 50%;
  transform: translateY(-20%) translatex(-50%);
  width: 500px;
  height: auto;
  border: 1px solid #EBEBFF;
  border-radius: 0.3rem;
  background-color: $white;
  padding: 1.5rem;
  
  &__form {
    &__close {
      position: absolute;
      opacity: .8;
      padding: 10px;
      right: 0;
      top: 0;
      cursor: pointer;
      background: transparent;
      border: 0;
      border-radius: 0;
      box-shadow: none;
      display: inline-block;
      height: 44px;
      vertical-align: top;
      visibility: inherit;
      width: 44px;
      
      &:hover {
        opacity: 1;
      }
      
      &:focus {
        outline: none;
      }
    }
  }
}
</style>