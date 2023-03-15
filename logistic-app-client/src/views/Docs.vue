<template>
    <div class="list">
        <h1 class="title report">Отчёты</h1>
        <!-- <input class="field__search form-control form-control-sm" type="text" placeholder="Поиск" v-model="search">         -->
        <div class="form-group">
        <a href="https://localhost:5001/api/docs/cars/"><button class="custom-btn btn-2">Отчет о авто</button></a>
        <a href="https://localhost:5001/api/docs/Trails/"><button class="custom-btn btn-2">Отчет о прицепах</button></a>
        <a href="https://localhost:5001/api/docs/Order/"><button class="custom-btn btn-2">Отчет о заказ</button></a>
        <a href="https://localhost:5001/api/docs/Person/"><button class="custom-btn btn-2">Сотрудники</button></a>
        </div>
     </div>
</template>


<style>
.custom-btn {
  width: 170px;
  height: 40px;
  color: #fff;
  border-radius: 5px;
  padding: 10px 25px;
  font-family: 'Lato', sans-serif;
  font-weight: 500;
  background: transparent;
  cursor: pointer;
  transition: all 0.3s ease;
  position: center;
  display: block;
  margin: 20px;
   box-shadow:inset 2px 2px 2px 0px rgba(255,255,255,.5),
   7px 7px 20px 0px rgba(0,0,0,.1),
   4px 4px 5px 0px rgba(0,0,0,.1);
  outline: none;
}
.btn-2 {
  background: rgb(8, 180, 171);
  border: none;
  
}
.btn-2:before {
  height: 0%;
  width: 2px;
}
.btn-2:hover {
  box-shadow:  4px 4px 6px 0 rgba(255,255,255,.5),
              -4px -4px 6px 0 rgba(116, 125, 136, .5), 
    inset -4px -4px 6px 0 rgba(255,255,255,.2),
    inset 4px 4px 6px 0 rgba(0, 0, 0, .4);
}
</style>