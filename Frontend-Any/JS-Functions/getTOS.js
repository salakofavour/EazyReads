async function getTOSByIDandName(){

    var input = document.getElementById("search").value
    var number = parseInt(input);

    if(Number.isNaN(number)){
        //changes number to a string 
        number = input;
    }else{
        //remains the same
        number=number;
    }

    try{
        const response  = await fetch("https://localhost:7020/api/CompanyDetails/"+input ,{
            method: "Get",
            headers : {"Content-Type" : "application/json"},
        }).then(res => res.json())
        .then(res => document.getElementById("viewToS").innerText = res.companyTos);
    }catch(e){        
        console.log(e.Message);
    }


}