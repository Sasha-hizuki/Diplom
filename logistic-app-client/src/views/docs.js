var docs = {selectore(value) {
    document.getElementById("Car").style.display = "none";
        document.getElementById("Order").style.display = "none";
        document.getElementById("trailer").style.display = "none";
    if (value == 'all'){
        document.getElementById("Car").style.display = "block";
        document.getElementById("Order").style.display = "block";
        document.getElementById("trailer").style.display = "block";
    }
    if (value == 0){
        document.getElementById("Order").style.display = "block";
    }
    if (value == 1){
        document.getElementById("trailer").style.display = "block";
    }
}}

export default docs;