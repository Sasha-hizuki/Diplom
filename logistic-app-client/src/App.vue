<template>
  <div id="app">
    <div class="row">
      <div class="col menu-wrap">
        <MenuList
        @helpVision="HelpVision"
        />
      </div>   
      <div class="col-wide">
        <div class="row">
          <div class="col-2 sub-menu">
            <router-view/>
          </div>        
          <div class="col-wide">
            <Map
            ref="map"
            :center="center"
            />
            <Help 
            v-if="Help_form"
            @helpVision="HelpVision"
            />
          </div>
        </div> 
      </div> 
    </div>       
  </div>
</template>

<script>

import MenuList from '@/components/MenuList'
import Map from '@/components/Map'
import Help from '@/components/Help'
export default {
  name: 'App', 
  components: {
    MenuList,
    Map,
    Help
  },
  data(){
    return{
      Help_form:false,
      center:{ lat: 53.89803, lng: 27.56483 }
    }    
  },
  methods:{
    HelpVision(){
      this.Help_form = !this.Help_form;
    }
  }
}
</script>

<style lang="scss">
  
@import url('https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700&display=swap');

*, *::before, *::after {
  box-sizing: border-box;
}
html {
  font-family: 'Roboto', sans-serif;
  font-size: 16px;
}
body {
  margin: 0;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.2;
  color: #4a4a4f;
  text-align: left;
}
#app {
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}
div, h1 {
  padding: 0;
  margin: 0;
}
  
button, [type="button"], [type="reset"], [type="submit"] {
  -webkit-appearance: button;
}
  
.btn {
  display: inline-block;
  font-weight: 500;
  color: $dark;
  cursor: pointer;
  text-align: center;
  vertical-align: middle;
  user-select: none;
  background-color: transparent;
  border: 2px solid transparent;
  padding: 0.45rem 0.85rem;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.9rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  
  &:focus {
    outline: none;
  }

  &_icon {
    display: inline-flex;
    align-items: center;

    span {
      margin-left: 8px;
    }
  }

  i {
    margin-left: -2px;
    font-weight: 700;
    font-size: 1.2rem;
    vertical-align:middle
  }

  span {
    vertical-align:middle
  }
  
  &-secondary {
    background-color: $white;
    border-color: $primary;
    
    &:hover {
      background-color: darken($white, 10%);
    }
    
    &:focus {
      outline: none;
      box-shadow: 0 0 0 0.2rem rgba($primary-light, 0.25);
    }
    
    i {
      color: $primary;
    }
  }
  
  &-primary {
    color: $white;
    background-color: $primary;
    border-color: $primary;
    
    &:hover {
      background-color: darken($primary, 10%);
      border-color: darken($primary, 10%);
    }
    
    &:focus {
      outline: none;
      box-shadow: 0 0 0 0.2rem rgba($primary-light, 0.25);
    }
  }

  &-sm {
    padding: 0.12rem 0.8rem;
    font-size: 0.82rem;
    line-height: 1.2;
    border-radius: 0.5rem;
    
    i {
      line-height: 0.6;
    }
  }
}

.modal {
  z-index: 1;
}
  
.form-control {
  display: block;
  width: 100%;
  height: calc(1.5em + 0.9rem + 2px);
  padding: 0.40rem 0.80rem;
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
  color: $dark;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid $gray;
  border-radius: 0.37rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  
  &:focus {
    outline: none;
    box-shadow: 0 0 0 0.2rem rgba($primary-light, 0.25);
    border-color: $primary-light;
  }
  
  &-sm {
    height: calc(1.2em + 0.7rem + 2px);
    padding: 0.30rem 0.45rem;
    font-size: 0.82rem;
    line-height: 1.2;
    border-radius: 0.2rem;
  }
}
  
.form-group {
  margin-bottom: 1.2rem;
  
  label {
    display: inline-block;
    margin-bottom: 4px;
  }
}
  
.form-row {
  display: flex;
  flex-wrap: wrap;
  margin-right: -5px;
  margin-left: -5px;
  
  .col {
    padding-left: 5px;
    padding-right: 5px;
    flex-basis: 0;
    flex-grow: 1;
    max-width: 100%;
  }
}
  
a {
  text-decoration: none;
  background-color: transparent;
  color: $dark;
}
ul {
  list-style:none;
  padding: 0;
  margin: 0;
}
.row {
  display: flex;
  flex-wrap: wrap;
}
.col, .col-2, .col-wide {
  width: 100%;
  position: relative;
}
.col {
  flex: 0 0 15%;
  max-width: 15%;  
  
  &-2 {
    flex: 0 0 20%;
    max-width: 20%;  
    height: 100vh;
    
    &:empty {
      display: none;
    }
  }
  
  &-wide {
    max-width: 100%;
    flex-grow: 1;
    flex-basis: 0;
    background-color: coral;
    padding: 0;
  }
}
.menu-wrap {
  background-color: $white;
}
.sub-menu {
  background-color: $light;
  padding: 0 20px;
  padding-top: 80px;
  position: inherit;
  overflow-y: auto;
}

</style>


