<?php
 include("cap.php");
 if(!isset($_GET['id']) || !file_exists("db/order/$_GET[id]")) exit();
 $file=file("db/order/$_GET[id]");

 echo"<table  id=tab1 CELLPADDING=10 CELLSPACING=0 align=center width=70%>
  <tr><td>Название</td><td>Количество</td><td>Цена</td><td>Стоимость</td></tr>";
 $i=1;
 foreach($file as $line)
   {   	 $line=trim($line);
   	 if(!strstr($line,"Общая стоимость заказа"))
   	   {   	   	  $expl=explode("*",$line);
          echo"<tr><td id=sett3>$expl[0]</td><td id=sett3>$expl[1]</td><td id=sett3>$expl[2]</td><td id=sett4>$expl[3]</td></tr>";
   	   }
   	else
   	  {   	    echo"<tr><td colspan=4 id=sett4>$line</td></tr>";
   	    break;
   	  }
    $i++;
   }
 echo"</table><br /><br />";

 echo"<table  id=tab1 CELLPADDING=10 CELLSPACING=0 align=center width=70%>";
  for($n=$i;$n<count($file);$n++)
     {       $file[$n]=trim($file[$n]);
       $expl=explode("*",$file[$n]);
       if($n==$i)
         {           $css1="id=sett5";
           $css2="";
         }
       else
         {           $css1="id=sett3";
           $css2="id=sett4";
         }
       echo"<tr><td $css1>$expl[0]</td><td $css2>$expl[1]</td></tr>";
     }

 echo"</table>";



?>

