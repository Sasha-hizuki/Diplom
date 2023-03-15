<template>
    <li class="list-item">
        <span class="item-item__info" v-on:click="$emit('get-item', item.id)">
            <strong>{{index+1}}</strong>
            {{item.fio}} <br> <div class="position-text">{{item.user_position.name}}</div>
        </span>
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
    }
}
</script>

<style lang="scss" scoped>
.position-text{
  color:gray;
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