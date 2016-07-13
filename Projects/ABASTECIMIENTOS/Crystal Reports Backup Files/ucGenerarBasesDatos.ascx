<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucGenerarBasesDatos.ascx.vb" Inherits="Controles_ucGenerarBasesDatos" %>
<%@ Register Src="ucMenu.ascx" TagName="ucMenu" TagPrefix="uc1" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label59" runat="server" Text="Ingrese los datos que a continuación se solicitan" /></td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center;" valign="top">
            <asp:Panel ID="pnlPaso1" runat="server"  Width="125px">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2" style="height: 29px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Generar Datos.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Código de la Licitación:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Nombre de la licitación:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label3" runat="server" Text="Nombre de la entidad que realiza la licitación:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label4" runat="server" Text="Descripción de la licitación:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label5" runat="server" Text="Nombre del titular:" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label6" runat="server" Text="Cargo del titular:" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label7" runat="server" Text="Fecha de inicio para solicitar aclaraciones:" /></td>
                        <td style="width: 100px">
                            <ew:calendarpopup id="CalendarPopup1" runat="server"></ew:calendarpopup>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label8" runat="server" Text="Fecha fin para solicitar aclaraciones:" /></td>
                        <td style="width: 100px">
                            <ew:calendarpopup id="CalendarPopup2" runat="server"></ew:calendarpopup>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; height: 9px;">
                            <asp:Label ID="Label9" runat="server" Text="Dirección de la UACI:" /></td>
                        <td style="width: 100px; height: 9px;">
                            <asp:Label ID="lblDireccionUACI" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label10" runat="server" Text="Municipio:" /></td>
                        <td style="width: 100px">
                            <asp:Label ID="lblMunicipio" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                        </td>
                        <td style="width: 100px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right; height: 21px;">
                        </td>
                        <td style="text-align: right; height: 21px;">
                            &nbsp;<asp:LinkButton ID="lbSiguiente1" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso2" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 2 Presentacion ofertas.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label11" runat="server" Text="Lugar:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label12" runat="server" Text="Dirección:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label13" runat="server" Text="Municipio:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label14" runat="server" Text="Fecha de inicio recepcion:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label15" runat="server" Text="Hora inicio recepción:" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList3" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label16" runat="server" Text="Fecha fin recepción:" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList4" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label17" runat="server" Text="Hora fin recepción:" /></td>
                        <td>
                            <ew:calendarpopup id="CalendarPopup3" runat="server"></ew:calendarpopup>
                        </td>
                    </tr><tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="lbBack1" runat="server">< Anterior</asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton1" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso3" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/paso 3 Apertura de ofertas.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label18" runat="server" Text="Lugar:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label19" runat="server" Text="Dirección:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label20" runat="server" Text="Municipio:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label21" runat="server" Text="Fecha de inicio de apertura:" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label22" runat="server" Text="Hora de inicio de apertura:" /></td>
                        <td style="width: 100px">
                            <asp:DropDownList ID="DropDownList5" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton9" runat="server">< Anterior</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso4" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/paso 4 Consultas y aclaraciones.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label23" runat="server" Text="Fecha de inicio:" /></td>
                        <td>
                            <ew:CalendarPopup ID="CalendarPopup4" runat="server">
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label24" runat="server" Text="Fecha fin:" /></td>
                        <td>
                            <ew:CalendarPopup ID="CalendarPopup5" runat="server">
                            </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton10" runat="server">< Anterior</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton3" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso5" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/paso 5 documentacion legal y financiera.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: left">
                            <asp:Label ID="Label25" runat="server" Text="Persona jurídica:" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left">
                            <asp:Label ID="Label27" runat="server" Text="Incluir los documentos legales y financieros que sean necesarios." /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:DataGrid ID="dgDocJuridicaOrigen" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                        <td style="width: 100px; text-align: center;">
                            <asp:DataGrid ID="dgDocJuridicaSeleccionado" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            &nbsp;</td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: left">
                            <asp:Label ID="Label28" runat="server" Text="Persona natural:" /></td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left">
                            <asp:Label ID="Label29" runat="server" Text="Incluir los documentos legales y financieros que sean necesarios." /></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: left">
                            &nbsp;</td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: center">
                            <asp:DataGrid ID="dgDocNaturalOrigen" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                        <td style="width: 100px; text-align: center">
                            <asp:DataGrid ID="dgDocNaturalSeleccionado" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton11" runat="server">< Anterior</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton4" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel><asp:Panel ID="pnlPaso6" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/paso 6 oferta tecnica.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label26" runat="server" Text="Incluir los documentos a solicitar de aspecto técnico necesario para cada renglon solicitado:" /></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            &nbsp;</td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: center">
                            <asp:DataGrid ID="DataGrid1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                        <td style="width: 100px; text-align: center;">
                            <asp:DataGrid ID="DataGrid2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton12" runat="server">< Anterior</asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton5" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso7" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Imagenes/paso 7 porcentajes de evaluacion.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Aspecto  técnico: " /></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            <asp:Label ID="Label31" runat="server" Text="Porcentaje global de calificación" /></td>
                        <td style="width: 100px">
                            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            &nbsp;<asp:Label ID="Label34" runat="server" Text="Incluya los criterios a evaluar para la oferta técnica" /></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:DataGrid ID="DataGrid3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                        <td style="text-align: center;">
                            <asp:DataGrid ID="DataGrid4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px; text-align: left">
                            <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Aspecto  Financiero:" /></td>
                        <td style="height: 21px; text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px; text-align: right">
                            <asp:Label ID="Label33" runat="server" Text="Porcentaje global de calificación" /></td>
                        <td style="height: 21px; text-align: left">
                            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            <asp:Label ID="Label35" runat="server" Text="Porcentaje para el índice de solvencia:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            <asp:Label ID="Label36" runat="server" Text="Porcentaje para el capital de trabajo:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            <asp:Label ID="Label37" runat="server" Text="Porcentaje para el índice de endeudamiento:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                            <asp:Label ID="Label38" runat="server" Text="Porcentaje para las referencias bancarias:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="LinkButton13" runat="server">< Anterior</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton6" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <table style="width: 748px">
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlPaso8" runat="server"  Width="125px" Visible="False">
                            <table style="width: 748px">
                                <tr>
                                    <td colspan="2">
                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Imagenes/paso 8 Garantias.jpg" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;" colspan="2">
                        <asp:Label ID="Label39" runat="server" Text="Garantía de mantenimiento de la oferta" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label40" runat="server" Text="Valor (Porcentaje):" /></td>
                                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label41" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
                                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label42" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
                                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label43" runat="server" Text="Lugar de entrega:" /></td>
                                    <td style="width: 100px">
                        <asp:TextBox ID="TextBox22" runat="server" Width="386px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                                    </td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="Label44" runat="server" Text="Garantía de cumplimiento de contrato" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label45" runat="server" Text="Valor (Porcentaje):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label46" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label47" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label48" runat="server" Text="Lugar de entrega:" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                                    </td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="Label53" runat="server" Text="Garantía de buena calidad" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label49" runat="server" Text="Valor (Porcentaje):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label50" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label51" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                        <asp:Label ID="Label52" runat="server" Text="Lugar de entrega:" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                                    </td>
                                    <td style="width: 100px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 595px; text-align: right">
                                    </td>
                                    <td style="text-align: right">
                                        <asp:LinkButton ID="LinkButton7" runat="server">Siguiente ></asp:LinkButton></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlPaso9" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/paso 9 Detalle productos.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:DataGrid ID="DataGrid5" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 220px; text-align: right">
                        </td>
                        <td style="text-align: right">
                            &nbsp;<asp:LinkButton ID="LinkButton8" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlPaso10" runat="server"  Width="125px" Visible="False">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/paso 10 Lugares y plazos de entrega.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center" valign="top">
                            <asp:Panel ID="pnlE1" runat="server"  Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label55" runat="server" Text="Para una entrega" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dgPrimera" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE2" runat="server"  Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label54" runat="server" Text="Para dos entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dgSegunda" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE3" runat="server"  Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label56" runat="server" Text="Para tres entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dgTercera" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE4" runat="server"  Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label57" runat="server" Text="Para cuatro entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="drCuarta" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE5" runat="server"  Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label58" runat="server" Text="Para cinco entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dgQuinta" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
