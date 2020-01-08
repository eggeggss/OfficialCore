function genPanel(color,id,title,detail){
    return '<div class="panel-group">' +
    '<div class="panel panel-default" >' +
      "<div class='panel-heading' style='background-color:"+color+"'>" +
        '<h4 class="panel-title" style="display:inline-block;">' +
          '<a data-toggle="collapse" href="#'+id+'">'+title+'</a>'+
      '</div>'+
      '<div id="'+id+'" class="panel-collapse collapse">'+
        '<ul class="list-group">'+
           detail +
          //li foreach
        '</ul>'+
      '</div>'+
     '</div>'+
   '</div>';
}


function paneicolitem(title,id,detail,color) {        
  return '<div class="panel-group">' +
            '<div class="panel panel-default" >' +
              "<div class='panel-heading' style='background-color:"+color+"'>" +
                '<h4 class="panel-title" style="display:inline-block;">' +
                  '<a data-toggle="collapse" href="#'+id+'">'+title+'</a>'+
                  '</h4><img class="add-ico" src="https://image.flaticon.com/icons/png/128/148/148781.png"><img class="del-ico" src="https://cdn4.iconfinder.com/data/icons/simplicio/128x128/file_delete.png">' +
              '</div>'+
              '<div id="'+id+'"class="panel-collapse collapse">'+
                '<ul class="list-group">'+
                   detail +
                  //li foreach
                '</ul>'+
              '</div>'+
             '</div>'+
           '</div>';
}
