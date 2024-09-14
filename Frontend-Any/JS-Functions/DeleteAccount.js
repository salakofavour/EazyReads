async function Delete(){

    var number= parseInt(document.getElementById("deleteId").value);
    try{
        const result = await fetch("https://localhost:7020/api/UserDetails/"+number, {
            method : "Delete",
            headers: {"Content-Type": "application/json"},
        });
        alert("user ", number, " deleted");
    }catch(e){
        console.log(e.Message);
    }

}


async function ViewAllAccountInfo(){
    try{
        const result = await fetch("https://localhost:7020/api/UserDetails/", {
            method : "Get",
            headers: {"Content-Type": "application/json"},
        })
        .then(res => res.json())
        .then(res => {
            res.map(each =>{
                document.getElementById("listUsers").innerHTML += "<tr> <td>"+each.userId+"</td> <td>"+each.userName+"</td> </tr>"
            });
        })
    }catch(e){
        console.log(e)
    }

}
