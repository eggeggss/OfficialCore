function genview(type,obj,length) {
    console.log(type);
        var data='';
        for (var i = 0; i < length; i++) {
           
           if (type=='0'){
            data = data +
            '<tr>' +
            '<td>預定送件日</td>' +
            '<td>' + obj[i]['dt_presend'] + '</td>' +
            '</tr>' +
            '<tr>' +
            '<td>送審時間</td>' +
            '<td>' + obj[i]['submit_date'] + '</td>' +
            '</tr>' +
            '<tr>' +
            '<td>送審文號</td>' +
            '<td><a href="'+obj[i]['submit_url']+'">' + obj[i]['submit_doc'] + '</a></td>' +
            '</tr>' +
            '<tr>' +
            '<td>審查回複</td>' +
            '<td>' + obj[i]['review_date'] + '</td>' +
            '</tr>' +
            '<tr>' +
            '<td>審查文號</td>' +
            '<td><a href="'+obj[i]['review_url']+'">' + obj[i]['review_doc'] + '</a></td>' +
            '</tr>' +
            '<tr>' +
            '<td>核可日期</td>' +
            '<td>' + obj[i]['check_date'] + '</td>' +// obj[i]['check_date']
            '</tr>' +
            '<tr class="doclink">' +
            '<td>核可文號</td>' +
            '<td><a href="'+obj[i]['check_url']+'">' + obj[i]['check_doc'] + '</a></td>' +
            '</tr>';

           }else if(type==1)
           {
                data = data +
                '<tr>' +
                '<td>負責廠商</td>' +
                '<td>' + obj[i]['host'] + '</td></tr>' +
                '<tr>' +
                '<td>會前會</td>' +
                '<td>' + obj[i]['dt_premeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>議價前會議</td>' +
                '<td>' + obj[i]['dt_preissuemeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>最後決定日</td>' +
                '<td>' + obj[i]['dt_predecidemeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>預定送件日</td>' +
                '<td>' + obj[i]['dt_presend'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審時間</td>' +
                '<td>' + obj[i]['submit_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審文號</td>' +
                '<td><a href="'+obj[i]['submit_url']+'">' + obj[i]['submit_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查回複</td>' +
                '<td>' + obj[i]['review_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查文號</td>' +
                '<td><a href="'+obj[i]['review_url']+'">' + obj[i]['review_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>核可日期</td>' +
                '<td>' + obj[i]['check_date'] + '</td>' +// obj[i]['check_date']
                '</tr>' +
                '<tr class="doclink">' +
                '<td>核可文號</td>' +
                '<td><a href="'+obj[i]['check_url']+'">' + obj[i]['check_doc'] + '</a></td>' +
                '</tr>';

           }else if(type==2)
           {
                data = data +
                '<tr>' +
                '<td>負責廠商</td>' +
                '<td>' + obj[i]['host'] + '</td></tr>' +
                '<tr>' +
                '<td>會前會</td>' +
                '<td>' + obj[i]['dt_premeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審前會議</td>' +
                '<td>' + obj[i]['dt_preissuemeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>預定送件日</td>' +
                '<td>' + obj[i]['dt_presend'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審時間</td>' +
                '<td>' + obj[i]['submit_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審文號</td>' +
                '<td><a href="'+obj[i]['submit_url']+'">' + obj[i]['submit_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查回複</td>' +
                '<td>' + obj[i]['review_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查文號</td>' +
                '<td><a href="'+obj[i]['review_url']+'">' + obj[i]['review_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>核可日期</td>' +
                '<td>' + obj[i]['check_date'] + '</td>' +// obj[i]['check_date']
                '</tr>' +
                '<tr class="doclink">' +
                '<td>核可文號</td>' +
                '<td><a href="'+obj[i]['check_url']+'">' + obj[i]['check_doc'] + '</a></td>' +
                '</tr>';

           }else if(type==3){
                data = data +
                '<tr>' +
                '<td>負責廠商</td>' +
                '<td>' + obj[i]['host'] + '</td></tr>' +
                '<tr>' +
                '<td>會前會</td>' +
                '<td>' + obj[i]['dt_premeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審前會議</td>' +
                '<td>' + obj[i]['dt_preissuemeeting'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>預定送件日</td>' +
                '<td>' + obj[i]['dt_presend'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審時間</td>' +
                '<td>' + obj[i]['submit_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>送審文號</td>' +
                '<td><a href="'+obj[i]['submit_url']+'">' + obj[i]['submit_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查回複</td>' +
                '<td>' + obj[i]['review_date'] + '</td>' +
                '</tr>' +
                '<tr>' +
                '<td>審查文號</td>' +
                '<td><a href="'+obj[i]['review_url']+'">' + obj[i]['review_doc'] + '</a></td>' +
                '</tr>' +
                '<tr>' +
                '<td>核可日期</td>' +
                '<td>' + obj[i]['check_date'] + '</td>' +// obj[i]['check_date']
                '</tr>' +
                '<tr class="doclink">' +
                '<td>核可文號</td>' +
                '<td><a href="'+obj[i]['check_url']+'">' + obj[i]['check_doc'] + '</a></td>' +
                '</tr>';
           }
             
        }
    
        return data;
    
    }