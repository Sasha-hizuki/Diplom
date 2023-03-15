<template>
    <li class="list-item">
        <span class="item-item__info" v-on:click="$emit('get-item', item.id)">
            <strong>Заказ №{{item.id}}</strong>
            <br> <span class="item-item__info__number">{{status}}</span>
        </span>
        <button class="btn show-route-btn" title="Отобразить заказ на карте" v-on:click="$emit('show-order', item.id)"></button>
        <button class="btn item-item__close" v-on:click="$emit('remove-item', item.id)">&times;</button>
    </li>
</template>

<script>
export default {
    props:{
        item:{
            type: Object,
            required: true
        },
        index: Number
    },
    computed:{
        status(){
            let word = null
            switch (this.item.status) {
            case 0:
                word = "Ожидает выполнения"
                break;
            case 1:
                word = 'На загрузке'
                break;
            case 2:
                word = 'В пути'
                break;
            case 3:
                word = 'На выгрузке'
                break;
            case 4:
                word = 'Завершен'
                break;
            }
            return word
        }
    }
}
</script>

<style lang="scss" scoped>
.show-route-btn{
    background-image: url(../assets/marker_icon.png);
    background-position: center;
    background-size: contain;
    background-repeat: no-repeat;
}
.list-item {
  border: 1px solid $gray;
  border-radius: 0rem;
  background-color: $white;
  display: flex;
  justify-content: space-between;
  padding: 12px 12px;
  border-radius: 0.2rem;
  
  + .list-item {
    margin-top: 8px;
  }
  
  &__info {
    &__number {
      font-size: 0.9rem;
    }
  }
  
  &__close {
    color: $primary;
    font-size: 1.3rem;
    line-height: 0.5;
    padding: 5px;
    cursor: pointer;
    border-radius: 0.3rem;
    
    &:focus {
      box-shadow: 0 0 0 0.2rem rgba($primary-light, 0.25);
    }
  }
}
</style>