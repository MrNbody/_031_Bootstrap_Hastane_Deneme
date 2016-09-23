<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.doktor.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/GirisCss.css" rel="stylesheet" />
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="../dist/sweetalert.css" rel="stylesheet" />
    <script src="../dist/sweetalert.min.js"></script>
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="divGiris">
                    <div class="form-group">
                        <label for="exampleInputEmail1" class="col-sm-2 control-label">Tc No</label>
                        <div class="col-sm-10">
                            <asp:TextBox CssClass="form-control" ID="textboxTc" placeholder="Tc no" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1" class="col-sm-2 control-label">Parola</label>
                        <div class="col-sm-10">
                            <asp:TextBox TextMode="Password" CssClass="form-control" ID="textboxParola" placeholder="Parola" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
                            <asp:Button ID="buttonGiris" CssClass="btn btn-default col-xs-12" runat="server" Text="Giriş Yap" OnClick="buttonGiris_Click" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="../bootstrap/js/jquery-3.1.0.min.js"></script>
    <script src="../bootstrap/js/bootstrap.js"></script>
    <script>
        function no(a) {
            swal({ title: "Başarısız!", text: a, type: "error", confirmButtonText: "Geri" });
        }
    </script>
    <script>
        function yes(a) {
            swal("Başarılı!", a, "success")
        }
    </script>
    <script>
        function loading() {
            swal({ title: "Yükleniyor!", text: "Lütfen bekleyiniz", timer: 500, showConfirmButton: false });
        }
    </script>
</body>
</html>
