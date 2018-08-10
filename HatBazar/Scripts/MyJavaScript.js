$(document).ready(function () {

   

    //$('#Product').click(function () {
    //    var i = this.StartDate;
    //    $('#result').load('/Report/Product?Type=i');
    //});
    $('#Order').click(function () {
        $('#result').load('/Report/Order');
    });
    function btn_click3() {
        $.get("/Report/Rubel", { id: '67', dd: 'Deepak' });  


    }
    
    $('#datepicker').datepicker();
    
    
});

function btn_click(StartDate, EndDate) {
  
    $('#result').load('/Report/Product? start =$StartDate;& End =$EndDate');
}

function btn_click2(StartDate, EndDate) {
    $('#result').load('/Report/Product');
}


/*'''''''''''''''''''''''''''''''''''''''''''''*/
