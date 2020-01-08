function init() {

    var url_more = '/Phone/More';
    var url_edit = "/Phone/Edit";
    $('.DeleteTag').click(function () {

        var id = $(this).data('phone-id');
        
        $('.more-info').load(url_more, { id: id });
    })

    $('.person-info').click(function () {

        var ename = $(this).data('ename');

        //alert('hello');
        $('.more-info').load(url_edit, { ename: ename });
    });

    /*
    $.busyLoadFull("show", {
        text: "loading...please wait",
        fontawesome: "fa fa-spinner fa-spin fa-3x fa-fw",
        background: "rgba(255, 152, 0, 0.86)",
    });

    setTimeout(function () {
        $.busyLoadFull("Hide");

    }, 1000);
    */
    //$('body').fadeOut(1).fadeIn(1000);
}


function bind() {
    
}
