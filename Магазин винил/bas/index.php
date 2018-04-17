<?php
$catalog='bas';
if(!file_exists("$catalog/admin/admin1.php"))exit("Не надо этот файл открывать!");
$conf=file("$catalog/admin/conf/sett.txt");
$conf[8]=trim($conf[8]);
?>
<style>
   #st
    {
      color:#004891;
      font-size:11pt;
      font-weight:300;
      font-family:"Times New Roman", "serif";
    }
   #st a
    {
      color:#004891;
      font-size:11pt;
      font-weight:300;
      font-family:"Times New Roman", "serif";
    }
    a.in
    {
      color:#004891;
      font-size:11pt;
      font-weight:300;
      font-family:"Times New Roman", "serif";
      text-decoration:none;
    }
   a.in:hover {text-decoration:underline}
</style>


    <div id="st"><img src=/<?php echo $catalog ?>/admin/img/bas.png alt=корзина border=0 align=middle>&nbsp;Ваша корзина пуста</div>
<script type="text/javascript">

 function rel()
  {
     if(navigator.appName=='Microsoft Internet Explorer' || navigator.appName=='Opera')
      {
      	window.history.go(0);
      }
     else
      {
      	window.location.reload();
      }
  }

function win_bas()
  {    window.open('/<?php echo $catalog ?>/form.php?op=1','','width=750,height=450,status=no,toolbar=no,menubar=no,scrollbars=yes')
  }

 function check_bas()
{
  var cookies=document.cookie.split('bas=');
  var count=0;
  var price=0;
     if(cookies.length>1)
       {
       	 cookies=document.cookie.split(';');
       	  for(var i=0; i < cookies.length; i++)
       	    {
              cookies_1=cookies[i].split('bas=');
              if(cookies_1.length > 1)
                {
                	cookies_1[1]=unescape(cookies_1[1]);
       	            count=cookies_1[1].split('|');
       	            count=count.length;
                }
       	       cookies_2=cookies[i].split('tot_p=');
              if(cookies_2.length > 1)  price=cookies_2[1];

       	    }
          document.getElementById("st").innerHTML="<img src=/<?php echo $catalog ?>/admin/img/bas.png alt=корзина border=0 align=middle>&nbsp;<a href=javascript:win_bas();>товаров в корзине "+count+"</a> на сумму "+price+ " <?php echo $conf[8];  ?>";

       }
     else document.getElementById("st").innerHTML="<img src=/<?php echo $catalog ?>/admin/img/bas.png alt=корзина border=0 align=middle>&nbsp;Ваша корзина пуста";
 }



 function c(n,p)
   {
     var p=Number(p);
     var ws=new Date();
     ws.setDate(1+ws.getDate());
     var cookies=new Array();
     cookies=document.cookie.split('bas=');

     if(cookies.length > 1)
       {
       	 cookies=document.cookie.split(';');
       	  for(var i=0; i < cookies.length; i++)
       	    {              cookies_1=cookies[i].split('bas=');
              if(cookies_1.length > 1)
                {                  cookies_1[1]=unescape(cookies_1[1]);
       	          cookies_1[1]=cookies_1[1]+"|"+n;
       	          document.cookie="bas="+cookies_1[1]+";  path=/; expires="+ ws.toGMTString();
                  break;
                }
       	    }
       }
    else
      {      	document.cookie="bas="+n+";  path=/; expires="+ ws.toGMTString();
      }

     cookies=document.cookie.split('tot_p=');
     if(cookies.length > 1)
       {
       	  cookies=document.cookie.split(';');
       	  for(var i=0; i < cookies.length; i++)
       	    {
              cookies_1=cookies[i].split('tot_p=');
              if(cookies_1.length > 1)
                {
                  cookies_1[1]=Number(cookies_1[1]);
                  cookies_1[1]+=p;
                  cookies_1[1]=Math.round(cookies_1[1]);
                  document.cookie="tot_p="+cookies_1[1]+";  path=/; expires="+ ws.toGMTString();
                }
       	    }
       }
    else
      {
      	 p=Math.round(p);
      	 document.cookie="tot_p="+p+";  path=/; expires="+ ws.toGMTString();
      }

   check_bas();
   }


check_bas();

</script>



