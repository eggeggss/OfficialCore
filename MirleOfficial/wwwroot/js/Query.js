function GetMasters(){
     
        console.log('getmaster');
        var me = $(this);
        
        if (me.data('requestRunning')) {
            return;
        }
        
        $.ajax({
            type: 'GET',
            url: '../app/doc/all',
            dataType: 'json',
            success: function (data) {
               
               $.busyLoadFull("show");
               var list='<option>None</option>';

               var length = data.length;
               if (length>0)
               {
                    for (var i = 0; i < length; i++) {

                        var docname=data[i].doc_name;
                        var id_doc_m=data[i].id_doc_m;
                        var type=data[i].type;                        
                        list=list+'<option id='+'m_'+type+'_'+id_doc_m+'>'+docname+'</option>';

                    }
               
                    //console.log(list);
                    //$('.form-control').append(list);
                    $('#sel1').append(list);
                    $('#sel2').append(list);
               }
               //console.log(data);
        
            },
            complete: function () {
             
                $.busyLoadFull("hide");  
                me.data('requestRunning', false);
            }
        });     
}


function GetDetail(type,id_doc_m){

    var me = $(this);
    
    if (me.data('requestRunning')) {
        return;
    }

    $.ajax({
        type: 'GET',
        url: '../app/doc/docd/'+type+'/'+id_doc_m,
        dataType: 'json',
        success: function (data) {
           
           $.busyLoadFull("show");
           var list='<option>None</option>';
           var detail='';
           var length = data.length;
           if (length>0)
           {
                for (var i = 0; i < length; i++) {
                    //title,id,detail,color
                    var name=data[i].name;
                    var id_doc_m=data[i].id_doc_m;
                    var id_doc_d=data[i].id_doc_d;
                    detail=detail+paneicolitem(name,'d'+'_'+id_doc_m+'_'+id_doc_d,'','#87CEFF');
                    /*
                    var docname=data[i].doc_name;
                    var id_doc_m=data[i].id_doc_m;
                    var type=data[i].type;                        
                    list=list+'<option id='+'m_'+type+'_'+id_doc_m+'>'+docname+'</option>';
                    */
                }
           
                $('#detail').append('<h1></h1>');
           }
           console.log(detail);
    
        },
        complete: function () {
         
            $.busyLoadFull("hide");  
            me.data('requestRunning', false);
        }
    }); 

}