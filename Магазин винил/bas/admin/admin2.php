<?php
   include("cap.php");

    if(isset($_GET['d']))
      {      	if(file_exists("db/order/$_GET[d]"))
      	  {      	    unlink("db/order/$_GET[d]");
      	    echo "<meta http-equiv=refresh content='0; url=admin2.php'>";
            exit();
      	  }
      }

    $file=array();
     $d=opendir("db/order");
      while(($e=readdir($d))!=false)
       {
         if($e =="." || $e ==".." || $e==".htaccess") continue;
         $file[]=$e;
       }
     closedir($d);

  rsort($file,SORT_NUMERIC);
if(count($file))
 {
  echo"<table  id=tab1 CELLPADDING=10 CELLSPACING=0 align=center width=30%>";
  foreach($file as $line)
    {
    	echo"<tr><td id=sett1><a class=order href=order.php?id=$line>".date("d.m.Y H:i",$line)."</a></td><td id=sett2 align=center><a href=admin2.php?d=$line><img src=img/del.png alt=удалить border=0></a></td></tr>";
    }

  echo"</table>";
 }

?>