<?php
include("cap.php");
$info="";
$data="";
if(isset($_POST['go']))
  {
    $_POST['login']=trim($_POST['login']);
    $_POST['pasv']=trim($_POST['pasv']);

    if($_POST['login']=="" || $_POST['pasv']=="")  $info=$info="<font color=red>��� ����� ����������� ��� ��������!</font><br />";
    if($info=="")
      {      	$file=file("conf/conf.txt");
        $f=fopen("conf/conf.txt","w");
        fwrite($f,md5($_POST['login'])."\r\n".md5($_POST['pasv'])."\r\n".$file[2]);
        fclose($f);
        $data="<br /><br /><font color=#408080>������ ��������!<br />����� �����&nbsp;<b>$_POST[login]</b><br />
        ����� ������&nbsp;<b>$_POST[pasv]</b></font><br />";
      }
  }




?>
<form name="" action="admin4.php" method="post">

<table id=tab align=center CELLPADDING=10 CELLSPACING=0 >
      <tr>
         <td >
         <?php
              if($data=="")
                 {                   if($info!="") echo $info;
                   echo" �����<br />
                      <input name=login type=text ><br />
                      ������<br />
                      <input name=pasv type=text><br /><br />
                      <input type=submit value=��������� id=m_button name=go>";

                 }
              else  echo $data;

         ?>
         </td>
      </tr>
</table>

</form>

</body>

</html>