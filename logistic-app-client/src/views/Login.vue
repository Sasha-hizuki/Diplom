<template>
    <div>
        <h1>Вход</h1>
        <form class="modal__form">            
            <div class="form-row">
                <div class="col form-group">
                    <label for="login" >Логин</label>
                    <input class="form-control" id="login" type="email" v-model="item.name" required autofocus>
                </div>
            </div>
            <div class="form-row">
                <div class="col form-group">
                    <label for="password" >Пароль</label>
                    <input class="form-control" id="password" type="password" v-model="item.password" required>
                </div>
            </div>
            <div>
                <button class="btn btn-sm btn-secondary new__btn" type="submit" v-on:click.prevent="handleSubmit">Войти</button>
            </div>
        </form>
    </div>
</template>

<script>
  export default {
    data(){
      return {
        item:{name : "", password : ""}      
      }
    },
    methods : {
      async handleSubmit(){
        if (this.item.password.length > 0) {
            await fetch('https://localhost:5001/api/token/', 
            { 
                method: 'POST',
                body: JSON.stringify(this.item),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => response.json())
            .then(json => {
                if(json.access_token){
                    localStorage.setItem('jwt',json.access_token)
                    if (localStorage.getItem('jwt') !== 'null' || localStorage.getItem('jwt') !== ''){
                        this.$router.push('/orders')
                    }
                }
                else{
                    alert("Неверные данные")
                }   
            })
            .catch(function (error) {
                console.error(error.response);
            });
        }
      }
    }
  }
</script>