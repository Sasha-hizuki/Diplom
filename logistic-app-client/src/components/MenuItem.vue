<template>
    <li class="menu-list__item">
        <router-link :to=item.url>{{item.title}}</router-link>
    </li>
</template>

<script>
export default {
    props:{
        item:{
            type: Object,
            required: true
        }
    }
}
</script>


<style lang="scss" scoped>
.menu-list__item {
  list-style:none;
  
  a {
    display: block;
    padding: 12px 20px;
    
    &.exact-active {
      background-color: $light;
      color: $primary;
      box-shadow: 0 -4px #42D9C8;
      font-weight: 500;
    }
    &:hover {
      color: $primary
    }
  }
}
</style>