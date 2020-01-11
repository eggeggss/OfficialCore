
function resetListiIem(trigger,target,event)
{
    $(trigger).on(event, function () {
        $(target).removeClass('item-click');
    });
}

function HttpGet(url){

    return $.get(url);
}

function GetMenus(url,lang,root) {

    HttpGet(url).done(function (data) {

        var $pro_kinds = data.Pro_kind;
        
        for (i = 0; i < $pro_kinds.length; i++)
        {
            var item = "<li class='dropdown-submenu2'> " +
                " <a href=" + root + lang + '/' + $pro_kinds[i].num + ">" + $pro_kinds[i].kind + "</a> " +
                " </li>";
            $('#product-item-menus').append(item);
        }
        
    });
}


function GetProdMenusDiv(url, lang, root) {

    HttpGet(url).done(function (data) {

        var $pro_kinds = data.Pro_kind;
        var $soluction_kinds = data.Solution_Kind;
       
        for (i = 0; i < $pro_kinds.length; i++) {

            var item = " " +
                " <a class='dropdown-item' href=" + root + lang + '/' + $pro_kinds[i].num + '/' + $pro_kinds[i].kind.replace('/','-')+ ">" + $pro_kinds[i].kind + "</a> " +
                "";
            $('#product-item-menus').append(item);
        }
        
    });
}



function GetSolutionMenusDiv(url, lang, root) {

    HttpGet(url).done(function (data) {

        var $soluction_kinds = data.Solution_Kind;

       
        if (lang==='English')
        {
            for (i = 0; i < $soluction_kinds.length; i++) {

                var item = " " +
                    " <a class='dropdown-item col-lg-12 col-4 text-left ' href=" + root + lang + '/' + $soluction_kinds[i].num + '/' + $soluction_kinds[i].kind.replace("/", "") + ">" + $soluction_kinds[i].kind + "</a> " +
                    "";
                $('#solution-item-menus').append(item);
            }
        } else {
            for (i = 0; i < $soluction_kinds.length; i++) {

                var item = " " +
                    " <a class='dropdown-item col-lg-4 col-4 text-left ' href=" + root + lang + '/' + $soluction_kinds[i].num + '/' + $soluction_kinds[i].kind.replace("/", "") + ">" + $soluction_kinds[i].kind + "</a> " +
                    "";
                $('#solution-item-menus').append(item);
            }
        }
        

    });
}


function bind() {
    
    $('.nav-item').each(function(indx,element){

        $(this).addClass('nav-item-default');
    });
    
    $('.nav-item').on('mouseenter',function(){
         $(this).toggleClass('nav-item-active');
    })
    
    $('.nav-item').on('mouseleave',function(){
        $(this).toggleClass('nav-item-active');
    })
    
    $('.dropdown-submenu').on('mouseenter',function(e){
          //不關閉list

          //if (!e) var e = window.event;
          //e.stopPropagation();
          //e.stopImmediatePropagation();
          //event = event || window.event;
          //e.preventDefault();
          /*
          if (!e) var e = window.event
          e.cancelBubble = true;
          if (e.stopPropagation) e.stopPropagation();
          */

          //event.stopPropagation();
          //關閉其他的
          $('.dropdown-menu').each(function(idx){

               $(this).removeClass('item-click');
          });

          //開自己的
          var $menu=$(this).find('.dropdown-menu')

          $menu.toggleClass('item-click'); 
          /*
          $menu.fadeIn(100,function(){
              $(this).toggleClass('item-click'); 
            } );*/                 
    })
     
    $('.navprod').on('mouseleave',function(){

        var $menu=$(this).find('.dropdown-menu')
        $menu.removeClass('item-click');
       
    })

    resetListiIem('.nav-item','.navprod','click');

}


