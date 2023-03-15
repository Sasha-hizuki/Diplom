<template>
    <div class="list">
        <h1 class="title">Заказы</h1>
        <!-- <input class="field__search form-control form-control-sm" type="text" placeholder="Поиск" v-model="search">         -->
        <div class="form-group">
            <label>Статус</label>
            <select class="form-control" v-model="StatusFilter">
                <option value="all">Все</option>
                <option value="0">Ожидает выполнения</option>
                <option value="1">На загрузке</option>
                <option value="2">В пути</option>
                <option value="3">На выгрузке</option>
                <option value="4">Завершено</option>
            </select>            
        </div>
        <div class="form-group">
            <label>Тип</label>
            <select class="form-control" v-model="TypeFilter">
                <option value="all">Все</option>
                <option value="import">Импорт</option>
                <option value="export">Экспорт</option>
            </select>
        </div>
        <button class="btn btn_icon btn-sm btn-secondary new__btn"  v-on:click.prevent="newItem"><i>&#43;</i><span>Добавить</span></button>
        <Loader v-if="loading"/>
        <ul class="items-list" v-else-if="searchItems.length">
            <Order
                v-for="(item) of searchItems" :key="item.id"
                v-bind:item="item"
                @remove-item="removeItem"
                @get-item="getItem"
                @show-order="showOrderOnMap"
            />
        </ul>
        <p v-else>Список пуст</p>
        <div v-if="Form" class="modal-big">
            <form id="From" class="modal__form" @submit.prevent="onSubmit">           
                <input v-if="item.id" v-model="item.id" type="hidden">
                <div class="form-row">
                    <div class="col form-group">
                        <label>Дата загрузки</label>
                        <input class="form-control" name="StartDate" required v-model="item.startDate" type="date">
                    </div>
                    <div class="col form-group">
                        <label>Дата доставки</label>
                        <input class="form-control" name="FinishDate" required v-model="item.finishDate" type="date">
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Тип</label>
                        <select class="form-control" v-model="item.type">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option value="import">Импорт</option>
                            <option value="export">Экспорт</option>
                        </select>
                    </div>
                    <div class="col form-group">
                        <label>Водитель</label>
                        <select class="form-control" v-model="item.driver.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Driver of DriversList" :key="Driver.id" :value=Driver.id>{{Driver.fio}}</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Автомобиль</label>
                        <select class="form-control" v-model="item.car.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Car of CarsList" :key="Car.id" :value=Car.id>{{Car.brand}} {{Car.number}}</option>
                        </select>
                    </div>
                    <div class="col form-group">
                        <label>Трейлер</label>
                        <select class="form-control" v-model="item.trailer.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Trailer of TrailersList" :key="Trailer.id" :value=Trailer.id>{{Trailer.brand}} {{Trailer.number}}</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Клиент</label>
                        <select class="form-control" v-model="item.client.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Client of ClientsList" :key="Client.id" :value=Client.id>{{Client.name}}</option>
                        </select>
                    </div>
                    <div class="col form-group">
                        <label>Декларант</label>
                        <select class="form-control" v-model="item.declarant.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Declarant of DeclarantsList" :key="Declarant.id" :value=Declarant.id>{{Declarant.name}}</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Таможня</label>
                        <select class="form-control" v-model="item.customs.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="Customs of CustomssList" :key="Customs.id" :value=Customs.id>{{Customs.name}}</option>
                        </select>
                    </div>
                    <div class="col form-group">
                        <label>Пункт пропуска</label>
                        <select class="form-control" v-model="item.borderCrossing.id">
                            <option disabled :value="null" selected hidden>Выберите один из вариантов</option>
                            <option v-for="BorderCrossing of BorderCrossingsList" :key="BorderCrossing.id" :value=BorderCrossing.id>{{BorderCrossing.name}}</option>
                        </select>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Адрес загрузки</label>
                        <input class="form-control" name="From" required v-model="item.from" type="text">
                    </div>
                    <div class="col form-group">
                        <label>Контакт на загрузке</label>
                        <input class="form-control" name="To" required v-model="item.fromContact" type="text">
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Адрес доставки</label>
                        <input class="form-control" name="To" required v-model="item.to" type="text">
                    </div>
                    <div class="col form-group">
                        <label>Ящик компании</label>
                        <input class="form-control" name="To" required v-model="item.toCompanyBox" type="text">
                    </div>
                </div>
                <div class="form-row">
                    <div class="col form-group">
                        <label>Номер контейнера</label>
                        <input class="form-control" name="ContainerNumber" required v-model="item.containerNumber" type="text">
                    </div>
                    <div class="col form-group">
                        <label>Вес контейнера</label>
                        <input class="form-control" name="Weight" required v-model="item.weight" type="number">
                    </div>
                </div>
                <input class="btn btn-primary" type="submit" value="Сохранить">
                <button class="modal-big__form__close" v-on:click.prevent="closeModal"><svg xmlns="http://www.w3.org/2000/svg" version="1" viewBox="0 0 24 24"><path d="M13 12l5-5-1-1-5 5-5-5-1 1 5 5-5 5 1 1 5-5 5 5 1-1z"></path></svg></button>
            </form>
        </div>
        <div v-if="routeForm" class="modal-route">
            <b>Информация о заказе №{{item.id}}</b>
            <div class="modal__form">
                <div class="form-row">
                    <div class="col form-group">
                        <label>Дата выезда: {{item.startDate}}</label>
                        <label>Дата доставки: {{item.startDate}}</label>
                        <label>Адрес загрузки: {{item.from}}</label>                        
                        <label>Адрес доставки: {{item.to}}</label>
                    </div>
                    <div class="col form-group">
                        <label>Водитель: {{item.driver.fio}}</label><br>
                        <label>Автомобиль: {{item.car.brand}} {{item.car.model}} {{item.car.number}}</label>
                    </div>
                </div>
            </div>
            <button class="modal-big__form__close" v-on:click.prevent="closeOrderModal"><svg xmlns="http://www.w3.org/2000/svg" version="1" viewBox="0 0 24 24"><path d="M13 12l5-5-1-1-5 5-5-5-1 1 5 5-5 5 1 1 5-5 5 5 1-1z"></path></svg></button>
        </div>
    </div>
</template>

<script>
import Loader from '@/components/Loader'
import Order from '@/components/Order'
import {Encoder} from '@/components/Encoder.js'
export default {
    data(){
        return {
            ItemsList:[],
            loading: true,
            Form:false,
            routeForm:false,
            item:{
                id:null,
                driver:{id:null},
                car:{id:null},
                trailer:{id:null},
                from:null,
                FromLocation:null,
                fromContact:null,
                to:null,
                ToLocation:null,
                toCompanyBox:null,
                weight:null,
                containerNumber:null,
                client:{id:null},
                declarant:{id:null},
                customs:{id:null},
                borderCrossing:{id:null},
                startDate:null,
                finishDate:null,
                status:null,
                type:null,
                CurrentLocation:null
            },
            DriversList:[],
            CarsList:[],
            TrailersList:[],
            ClientsList:[],
            DeclarantsList:[],
            CustomssList:[],
            BorderCrossingsList:[],
            StatusFilter:"all",
            TypeFilter:"all"
        }
    },
    computed:{
        searchItems(){
            let filtered_data = this.ItemsList;
            if(this.TypeFilter != 'all' ){
                filtered_data = this.ItemsList.filter(c => c.type.toLowerCase().startsWith(this.TypeFilter))
            }
            if(this.StatusFilter != 'all' ){
                filtered_data = this.ItemsList.filter(c => c.status == this.StatusFilter)
            }
            return filtered_data;
        }
    },
    methods:{
        async removeItem(id){
            await fetch('https://localhost:5001/api/deliverytasks/'+id, { 
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
            await fetch('https://localhost:5001/api/deliverytasks/',{
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
            this.closeOrderModal()
            await this.getItemData(id).then(()=>this.openModal())
        },
        async getItemData(id){
            await fetch('https://localhost:5001/api/users/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.DriversList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/cars/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.CarsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/trailers/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.TrailersList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/clients/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.ClientsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/declarants/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.DeclarantsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/customs/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.CustomssList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/bordercrossings/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.BorderCrossingsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/deliverytasks/'+id,{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.item = json;
                this.item.startDate = this.item.startDate.split('T')[0];
                this.item.finishDate = this.item.finishDate.split('T')[0];
            })
        },
        async newItem(){
            if(this.routeForm)
                this.closeOrderModal();
            await fetch('https://localhost:5001/api/users/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.DriversList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/cars/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.CarsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/trailers/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.TrailersList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/clients/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.ClientsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/declarants/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.DeclarantsList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/customs/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.CustomssList = json                
                this.loading = false
            })
            await fetch('https://localhost:5001/api/bordercrossings/',{
               headers: {
                    'Content-Type': 'application/json',
                    'Cache-Control': 'no-cache',
                    'Authorization': 'Bearer '+ localStorage.getItem('jwt')
                }
            })
            .then(response => response.json())
            .then(json => {
                this.BorderCrossingsList = json                
                this.loading = false
            })
            this.item = {
                id:null,
                driver:{id:null},
                car:{id:null},
                trailer:{id:null},
                from:null,
                FromLocation:null,
                fromContact:null,
                to:null,
                ToLocation:null,
                toCompanyBox:null,
                weight:null,
                containerNumber:null,
                client:{id:null},
                declarant:{id:null},
                customs:{id:null},
                borderCrossing:{id:null},
                startDate:null,
                finishDate:null,
                status:null,
                type:null,
                CurrentLocation:null
            };
            this.openModal()
        },
        openModal(){            
            this.Form = true;
        },
        closeModal(){
            this.Form = false;
            this.item = {
                id:null,
                driver:{id:null},
                car:{id:null},
                trailer:{id:null},
                from:null,
                FromLocation:null,
                fromContact:null,
                to:null,
                ToLocation:null,
                toCompanyBox:null,
                weight:null,
                containerNumber:null,
                client:{id:null},
                declarant:{id:null},
                customs:{id:null},
                borderCrossing:{id:null},
                startDate:null,
                finishDate:null,
                status:null,
                type:null,
                CurrentLocation:null
            };
            this.selectedItem = null;
        },
        async onSubmit(){
            await Encoder.EncodeAddress(this.item.from).then(c => this.item.FromLocation = c)
            await Encoder.EncodeAddress(this.item.to).then(c => this.item.ToLocation = c)
            if(this.item.id){
                await fetch('https://localhost:5001/api/deliverytasks/'+this.item.id, 
                { 
                    method: 'PUT',
                    body: JSON.stringify(this.item, function(key, value){
                        if(key === "weight"){
                            return parseFloat(value)
                        }                        
                        return value
                    }),
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
                this.item.status = 0
                await fetch('https://localhost:5001/api/deliverytasks/', 
                { 
                    method: 'POST',
                    body: JSON.stringify(this.item, function(key, value){
                        if(key === "weight"){
                            return parseFloat(value)
                        }                         
                        return value
                    }),
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
            
        },
        async showOrderOnMap(id){
            if(this.Form)
                this.closeModal()
            await this.getItemData(id).then(()=>{
                this.$root.$refs.MapComponent.dropOrder(this.item);
            }) 
            this.routeForm = true;           
        },
        closeOrderModal(){      
            this.$root.$refs.MapComponent.removeOrder();     
            this.routeForm = false;
            this.item = {
                id:null,
                driver:{id:null},
                car:{id:null},
                trailer:{id:null},
                from:null,
                FromLocation:null,
                fromContact:null,
                to:null,
                ToLocation:null,
                toCompanyBox:null,
                weight:null,
                containerNumber:null,
                client:{id:null},
                declarant:{id:null},
                customs:{id:null},
                borderCrossing:{id:null},
                startDate:null,
                finishDate:null,
                status:null,
                type:null
            };
        }
    },
    async mounted(){
        this.getItems()
    },
    components:{
        Loader, Order
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
.modal-big {
  z-index: 3;
  position: absolute;
  top: 20%;
  left: 60%;
  transform: translateY(-20%) translatex(-50%);
  width: 900px;
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
.modal-route {
  z-index: 3;
  position: absolute;
  bottom: 5%;
  left: 60%;
  transform: translateY(-20%) translatex(-50%);
  width: 800px;
  height: 200px;
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