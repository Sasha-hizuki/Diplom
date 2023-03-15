<template>
    <div class="map" id="map">
      <div id="mapContainer" style="height:100%;width:100%" ref="map"></div>
    </div>
</template>

<script>
export default {
  name: "HereMap",
  data(){
    return{
      platform: {},
      map: {},
      routingService: {}
    }
  },
  props: {
    apiKey: String,
    center: Object,
    zoom: String
  },
  created(){    
    const H = window.H;
    this.platform = new H.service.Platform({
      "apiKey": "hmElVIv8inBvHDEg0ywBk5bAsYOXG09ElG5Mna_Fmdk"
    });
    this.routingService = this.platform.getRoutingService();
    this.$root.$refs.MapComponent = this
  },
  mounted(){
    const H = window.H;
    this.map = new H.Map(
      this.$refs.map,
      this.platform.createDefaultLayers().vector.normal.map,
      {
        zoom: 6,
        center: { lat: this.center.lat, lng: this.center.lng}
      }
    );
      new H.mapevents.Behavior(new H.mapevents.MapEvents(this.map));
      var maptypes = this.platform.createDefaultLayers();
      H.ui.UI.createDefault(this.map, maptypes);
  },
  methods:{
    dropOrder: function(order){
      this.removeOrder();
      const H = window.H;
      // let fromImage = '';
      // let toImage = '';
      // let fromIcon = new H.map.Icon(fromImage);
      // let toIcon = new H.map.Icon(toImage);
      let fromMarker = new H.map.Marker(
        { 
          lat:order.fromLocation.split(',')[0], 
          lng:order.fromLocation.split(',')[1]
        },
        {
          //icon:fromIcon
        }
      );
      let toMarker = new H.map.Marker(
        { 
          lat:order.toLocation.split(',')[0], 
          lng:order.toLocation.split(',')[1]
        },
        {
          //icon:toIcon
        }
      );
      this.map.addObject(fromMarker);
      this.map.addObject(toMarker);
      this.drawRoute(order.fromLocation, order.toLocation);
    },
    removeOrder: function(){
      this.map.removeObjects(this.map.getObjects())
    },
    async drawRoute(start, finish){
      const H = window.H;
      await this.routingService.calculateRoute(
        {
          "mode":"fastest;car;traffic:enabled",
          "waypoint0":`${start.split(',')[0]},${start.split(',')[1]}`,
          "waypoint1":`${finish.split(',')[0]},${finish.split(',')[1]}`,
          "representation":"display"
        },
        data => {
          if(data.response.route.length > 0){
            let lineString = new H.geo.LineString();
            data.response.route[0].shape.forEach(point => {
              let [lat, lng] = point.split(",");
              lineString.pushPoint({lat:lat,lng:lng});
            });
            let polyline = new H.map.Polyline(
              lineString,
              {
                style:{
                  lineWidth: 5
                }
              }
            );
            this.map.addObject(polyline);
          }
        },
        error => {
          console.error(error)
        }
      );
    }
  }
}
</script>

<style>
.map {
  height: 100vh;
}   
</style>