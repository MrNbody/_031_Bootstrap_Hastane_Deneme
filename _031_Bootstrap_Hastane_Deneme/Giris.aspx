<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="_031_Bootstrap_Hastane_Deneme.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="css/GirisCss.css" rel="stylesheet" />
    <script src="dist/sweetalert.min.js"></script>
    <link href="dist/sweetalert.css" rel="stylesheet" />
</head>
<body>
    <form class="form-horizontal" id="form1" runat="server">
        <asp:ScriptManager ID="sm" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divGiris">
                    <div class="form-group">
                        <div class="btn-group" role="group" aria-label="...">
                            <asp:Button ID="buttonGirisPanel" CssClass="btn btn-default" Text="Giris" runat="server" OnClick="buttonGirisPanel_Click" />
                            <asp:Button ID="buttonKaydolPanel" CssClass="btn btn-default" Text="Kaydol" runat="server" OnClick="buttonKaydolPanel_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1" class="col-sm-2 control-label">Tc No</label>
                        <div class="col-sm-10">
                            <asp:TextBox CssClass="form-control" ID="textboxTc" placeholder="Tc no" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Panel ID="panelKaydol" Visible="false" runat="server">
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Ad</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxAd" placeholder="Ad" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Soyad</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxSoyad" placeholder="Soyad" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Cinsiyet</label>
                            <div class="col-sm-10">
                                <asp:DropDownList CssClass="form-control" ID="dropdawnlistCinsiyet" placeholder="Cinsiyet" runat="server">
                                    <asp:ListItem>Erkek</asp:ListItem>
                                    <asp:ListItem>Kadın</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Doğum Yeri</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxDogumYeri" placeholder="Doğum Yeri" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Doğum Tarihi</label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Date" CssClass="form-control" ID="textboxDogumTarihi" placeholder="Doğum Tarihi" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Baba Adı</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxBabaAdı" placeholder="Baba Adı" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Anne adı</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxAnneAdı" placeholder="Anne Adı" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Telefon</label>
                            <div class="col-sm-10">
                                <asp:TextBox CssClass="form-control" ID="textboxTelefon" placeholder="Telefon" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="col-sm-2 control-label">Email</label>
                            <div class="col-sm-10">
                                <asp:TextBox TextMode="Email" CssClass="form-control" ID="textboxEmail" placeholder="Email" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
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
    <script src="bootstrap/js/jquery-3.1.0.min.js"></script>
    <script src="bootstrap/js/bootstrap.js"></script>
    <script>
        function no(a) {
            swal({ title: "Başarısız", text: a, type: "error", confirmButtonText: "Geri" });
        }
    </script>
    <script>
        function yes() {
            swal("Başarılı!", "Kaydınız alınmıştır", "success")
        }
    </script>
    <script>
        function loading() {
            swal({ title: "Yükleniyor!", text: "Lütfen bekleyiniz", timer: 500, showConfirmButton: false });
        }
    </script>
</body>
</html>
