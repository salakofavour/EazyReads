    //default placeholder
    var number= 1; //parseInt(document.getElementById("deleteId").value);

async function ViewAccountInfo(){
    try{
        const result = await fetch("https://localhost:7020/api/UserDetails/"+number, {
            method : "Get",
            headers: {"Content-Type": "application/json"},
        })
        .then(res => res.json())
        .then(res => {
            console.log("view",res);
            document.getElementById("id").value = res.userId;
            document.getElementById("name").value = res.userName;
            document.getElementById("paid").value = res.hasPriviledgedAccess;
        })
    }catch(e){
        console.log(e)
    }

}

async function EditAccountInfo(e){
    e.preventDefault();

    var userId = parseInt(document.getElementById("id").value);
    var userName = document.getElementById("name").value;
    var hasPriviledgedAccess = document.getElementById("paid").value;
    if(hasPriviledgedAccess == "false"){
        hasPriviledgedAccess = false;
    }else{
        hasPriviledgedAccess=true;
    }
    try{
        const result = await fetch("https://localhost:7020/api/UserDetails/"+number, {
            method : "Put",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify({userId, userName, hasPriviledgedAccess})
        }).then(res => res.json())
        .then(res =>  console.log("edit",res));

        alert("user ", number, " account details are changed, refresh page to view");
    }catch(e){
        console.log(e)
    }

}