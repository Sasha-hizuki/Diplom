export const Encoder = {
    EncodeAddress: async function(address) {
        let responce;
        await fetch('https://geocode.search.hereapi.com/v1/geocode?q='+address+'&apiKey=32spC4r3MutuuHL1dh7Qh1eTDqYP64Zn5VGNab8Daoo')
                .then(response => response.json())
                .then(json => {
                    responce =  json.items[0].position.lat+","+json.items[0].position.lng;
                })
        return responce
    }
  };