<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deneme.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.deneme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="bootstrap/js/jquery-3.1.0.min.js"></script>
    <script src="bootstrap/js/bootstrap.js"></script>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="veri">
        </div>
    </form>
    <script type="text/javascript">

        var json = JSON.stringify({ ders1: "php", ders2: "javascript", ders3: "css" });

        var oku = JSON.parse(json);

        document.getElementById("veri").innerHTML = oku.ders1 + "-" + oku.ders2 + "-" + oku.ders3;

    </script>
</body>
</html>
