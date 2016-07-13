<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Notificacion_NuevaNotificacion.ascx.vb" Inherits="Controles_Notificacion_NuevaNotificacion" %>
<hr />

          <table class="CenteredTable" style="width: 100%">
           
            <tr>
                <td class="LabelCell" style="white-space: nowrap">
                Fecha de Notificación: </td>
              <td class="DataCell">
              
             
                        <asp:TextBox runat="server" CssClass="datefield" ID="tbFecha" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                      ControlToValidate="tbFecha" ValidationGroup="nuevanota" ToolTip="Fecha Obligatoria"/>
                </td>
            </tr>
              
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Nombre Comercial:</td>
              <td class="DataCell" style="width: 100%">
                <asp:TextBox ID="tbNombreComercial" runat="server" TextMode="MultiLine" Width="85%" CssClass="TextBoxMultiLine" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbNombreComercial" ValidationGroup="nuevanota"/>
                </td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Laboratorio Fabricante:</td>
              <td class="DataCell">
                <asp:TextBox ID="tbLaboratorio" runat="server" Width="309px" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbLaboratorio" ValidationGroup="nuevanota"/>
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                No.Lote:</td>
              <td class="DataCell">
                <asp:TextBox ID="tbNoLote" runat="server" Width="99px" MaxLength="15" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" 
                                              ControlToValidate="tbNoLote"
                                              ValidationGroup="nuevanota" ToolTip="Lote Obligatorio"/>
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Tamaño de Lote:</td>
              <td class="DataCell">
                <asp:TextBox ID="tbTamanioLote" runat="server"  Width="77px" CssClass="numeric" />
                <asp:DropDownList ID="ddlUNIDADMEDIDAS1" runat="server" Visible="False" />
                <asp:Label ID="Label2" runat="server" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                     ControlToValidate="tbTamanioLote" ErrorMessage="*" ValidationGroup="nuevanota"/>
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Fecha de Fabricación:</td>
              <td class="DataCell">
                  <asp:TextBox runat="server" ID="tbFechaPublicacion" CssClass="monthyearfield"/>
                  <asp:RequiredFieldValidator ID="rfvFechaPublicacion" runat="server" ErrorMessage="*"
                      ValidationGroup="nuevanota" ControlToValidate="tbFechaPublicacion"/>
                  <asp:CheckBox ID="chbFFnoaplica" runat="server" Text="N/A" AutoPostBack="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Fecha de Vencimiento:</td>
              <td class="DataCell">
                  <asp:TextBox runat="server" ID="tbFechaVencimiento" CssClass="monthyearfield"/>
                  <asp:RequiredFieldValidator ID="rfvFechaVencimiento" runat="server" ErrorMessage="*"
                      ControlToValidate="tbFechaVencimiento"  ValidationGroup="nuevanota"/>
               
                  <asp:CheckBox ID="chbFVnoaplica" runat="server" Text="N/A" AutoPostBack="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Cantidad total a entregar del lote:</td>
              <td class="DataCell">
                <asp:TextBox ID="tbCantidadEntregar" runat="server"  Width="77px"  CssClass="numeric"/>
                <asp:DropDownList ID="DdlUNIDADMEDIDAS2" runat="server" Visible="False" />
                <asp:Label ID="Label3" runat="server" />

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                     ValidationGroup="nuevanota" ControlToValidate="tbCantidadEntregar" />
              </td>
            </tr>
           
          </table>
