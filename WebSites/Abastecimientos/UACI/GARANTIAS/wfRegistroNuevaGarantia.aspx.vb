Imports ABASTECIMIENTOS.NEGOCIO
Imports ABASTECIMIENTOS.ENTIDADES
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Class UACI_GARANTIAS_wfRegistroNuevaGarantia
    Inherits System.Web.UI.Page
    Private _id As Integer
    Private TFechas As Data.DataTable

    Public Property ide() As Integer
        Get
            Return Me._id
        End Get
        Set(ByVal value As Integer)
            Me._id = value
            If Not Me.ViewState("id") Is Nothing Then Me.ViewState.Remove("id")
            Me.ViewState.Add("id", value)
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.Master.ControlMenu.Visible = False
            Select Case Request.QueryString("idtg")
                Case Is = 1
                    Me.Label1.Text = "Mantenimiento de Oferta"
                    Me.Label2.Text = "MANTENIMIENTO DE OFERTA"
                Case Is = 2
                    Me.Label1.Text = "Buena Inversión de Anticipo"
                    Me.Label2.Text = "BUENA INVERSIÓN DE ANTICIPO"
                Case Is = 3
                    Me.Label1.Text = "Cumplimiento de Contrato"
                    Me.Label2.Text = "CUMPLIMIENTO DE CONTRATO"
                Case Is = 4
                    Me.Label1.Text = "Buena Obra"
                    Me.Label2.Text = "BUENA OBRA"
                Case Is = 5
                    Me.Label1.Text = "Buen servicio, Funcionamiento y Calidad de los Bienes"
                    Me.Label2.Text = "BUEN SERVICIO, FUNCIONAMIENTO Y CALIDAD DE LOS BIENES"
            End Select

            cargardatos()

            If Request.QueryString("id") Is Nothing Then
                'nuevo
                Me.Button4.Visible = False
                Me.Button5.Visible = False
                Select Case Request.QueryString("idtg")
                    Case Is = 1

                        Me.Label15.Text = "Fecha de Apertura de Oferta:"
                        Me.Label9.Visible = False
                        Me.TextBox3.Visible = False
                        Me.Label10.Visible = False
                        Me.TextBox4.Visible = False
                        Me.Label11.Visible = False

                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False


                        Me.Label31.Visible = False
                        Me.TextBox15.Visible = False
                        Me.Label32.Visible = False

                        Me.Label33.Visible = False
                        Me.TextBox16.Visible = False
                        Me.Label35.Visible = False

                        Me.Label34.Visible = False
                        Me.TextBox17.Visible = False
                        Me.Label36.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False


                        Me.Label53.Visible = False
                        Me.TextBox26.Visible = False

                        Me.Panel1.Visible = False

                        Me.RequiredFieldValidator3.Enabled = False
                        Me.RequiredFieldValidator4.Enabled = False
                        Me.CompareValidator1.Enabled = False

                    Case Is = 2
                        Me.Label16.Visible = True '
                        Me.TextBox8.Visible = True '
                        Me.Button6.Visible = True '
                        Me.RequiredFieldValidator9.Visible = False
                        Me.CompareValidator4.Visible = False
                        Me.Label17.Visible = True
                        Me.Label19.Visible = True


                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False


                    Case Is = 3
                        Me.Label15.Text = "Fecha Inicio de vigencia de la Garantía:"
                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False


                    Case Is = 4

                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label53.Visible = False
                        Me.TextBox26.Visible = False

                    Case Is = 5
                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False

                End Select
            Else
                'edicion
                Me.UpdatePanel2.Visible = True
                Me.Button4.Visible = True
                Me.Button5.Visible = True
                Me.Button5.Enabled = True
                ide = Request.QueryString("id")
                Dim g As New REGISTROGARANTIAS
                Dim cg As New cREGISTROGARANTIAS
                Dim ds As New Data.DataSet
                ds = cg.ObtenerRegistroUnaGarantia(Request.QueryString("id"), Session("IdEstablecimiento"))
                Me.Label55.Text = ds.Tables(0).Rows(0).Item("IDPROVEEDOR")
                Dim cp As New cPROVEEDORESCG
                Dim dsprov As New Data.DataSet
                dsprov = cp.ObtenerProveedorPorIdProveedor(Session("IdEstablecimiento"), ds.Tables(0).Rows(0).Item("IDPROVEEDOR"))
                Me.Label4.Text = dsprov.Tables(0).Rows(0).Item(1).ToString
                Me.Label5.Text = dsprov.Tables(0).Rows(0).Item(2).ToString

                Select Case Request.QueryString("idtg")
                    Case Is = 1
                        Me.Label15.Text = "Fecha de Apertura de Oferta:"
                        Me.Label9.Visible = False
                        Me.TextBox3.Visible = False
                        Me.Label10.Visible = False
                        Me.TextBox4.Visible = False
                        Me.Label11.Visible = False

                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False


                        Me.Label31.Visible = False
                        Me.TextBox15.Visible = False
                        Me.Label32.Visible = False

                        Me.Label33.Visible = False
                        Me.TextBox16.Visible = False
                        Me.Label35.Visible = False

                        Me.Label34.Visible = False
                        Me.TextBox17.Visible = False
                        Me.Label36.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False


                        Me.Label53.Visible = False
                        Me.TextBox26.Visible = False

                        Me.Panel1.Visible = False

                        Me.RequiredFieldValidator3.Enabled = False
                        Me.RequiredFieldValidator4.Enabled = False
                        Me.CompareValidator1.Enabled = False

                        If ds.Tables(0).Rows.Count > 0 Then
                          

                            Me.RadioButtonList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPODOCUMENTO")
                            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")

                            Me.DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("IDENTIDAD")
                            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item("NUMGARANTIA")
                            Me.TextBox6.Text = CStr(Format(ds.Tables(0).Rows(0).Item("MONTO"), "0.00"))
                            Me.TextBox7.Text = CDate(ds.Tables(0).Rows(0).Item("FECHAEMISION"))
                            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item("TOTALDIAS")
                            Me.Label19.Text = CDate(ds.Tables(0).Rows(0).Item("FECHAVTO"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA")) Then
                                Me.TextBox21.Text = CStr(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA"))
                            Else
                                Me.TextBox21.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARESFIRME")) Then
                                Me.TextBox22.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARESFIRME"))
                            Else
                                Me.TextBox22.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHADEVGTIA")) Then
                                Me.TextBox24.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADEVGTIA"))
                            Else
                                Me.TextBox24.Text = ""
                            End If
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA")) Then
                                Me.TextBox25.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA"))
                            Else
                                Me.TextBox25.Text = ""
                            End If

                            Me.DropDownList3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDCAUSAL")), 0, ds.Tables(0).Rows(0).Item("IDCAUSAL"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACIONES")) Then
                                Me.TextBox27.Text = ds.Tables(0).Rows(0).Item("OBSERVACIONES")
                            Else
                                Me.TextBox27.Text = ""
                            End If

                        End If


                    Case Is = 2

                        Me.Label16.Visible = True '
                        Me.TextBox8.Visible = True '
                        Me.Button6.Visible = True '
                        Me.RequiredFieldValidator9.Visible = False
                        Me.CompareValidator4.Visible = False
                        Me.Label17.Visible = True '
                        Me.Label19.Visible = True '

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False

                        If ds.Tables(0).Rows.Count > 0 Then

                            Me.Label55.Text = ds.Tables(0).Rows(0).Item("IDPROVEEDOR")
                            Me.RadioButtonList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPODOCUMENTO")
                            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")

                            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item("NUMCONTRATO")
                            Me.TextBox4.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADISTRIBUCION"))


                            Me.DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("IDENTIDAD")
                            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item("NUMGARANTIA")
                            Me.TextBox6.Text = CStr(Format(ds.Tables(0).Rows(0).Item("MONTO"), "0.00"))
                            Me.TextBox7.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEMISION"))
                            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item("TOTALDIAS") ''
                            Me.Label19.Text = CDate(ds.Tables(0).Rows(0).Item("FECHAVTO"))


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEJEANT")) Then
                                Me.Label19.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEJEANT"))
                            Else
                                'Me.Label19.Text = ""
                                Me.Label19.Text = CDate(ds.Tables(0).Rows(0).Item("FECHAVTO"))

                            End If

                            'Me.TextBox8.Text = ""
                            'Me.Label19.Text = ""

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAAPRPLANUTIANT")) Then
                                Me.TextBox9.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAAPRPLANUTIANT"))
                            Else
                                Me.TextBox9.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAUTIPLANAVFI")) Then
                                Me.TextBox10.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAUTIPLANAVFI"))
                            Else
                                Me.TextBox10.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPGTIACUMCON")) Then
                                Me.TextBox11.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPGTIACUMCON"))
                            Else
                                Me.TextBox11.Text = ""
                            End If

                            'CARGAR FECHAS
                            Dim y As New cREGISTROGARANTIAS
                            Dim DSFECHAS As New Data.DataSet
                            DSFECHAS = y.ObtenerFechas(Request.QueryString("id"), Session("IDESTABLECIMIENTO"))
                            If DSFECHAS.Tables(0).Rows.Count > 0 Then
                                TFechas = DSFECHAS.Tables(0)
                                Me.GridView1.DataSource = DSFECHAS
                                Me.GridView1.DataBind()
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA")) Then
                                Me.TextBox15.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA"))
                            Else
                                Me.TextBox15.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI")) Then
                                Me.TextBox16.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI"))
                            Else
                                Me.TextBox16.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARECUFI")) Then
                                Me.TextBox17.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARECUFI"))
                            Else
                                Me.TextBox17.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEJEANT")) Then
                                Me.TextBox18.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEJEANT"))
                            Else
                                Me.TextBox18.Text = ""
                            End If



                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA")) Then
                                Me.TextBox21.Text = CStr(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA"))
                            Else
                                Me.TextBox21.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHADEVGTIA")) Then
                                Me.TextBox24.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADEVGTIA"))
                            Else
                                Me.TextBox24.Text = ""
                            End If
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA")) Then
                                Me.TextBox25.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA"))
                            Else
                                Me.TextBox25.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VALORCUANTIA")) Then
                                Me.TextBox26.Text = CStr(Format(ds.Tables(0).Rows(0).Item("VALORCUANTIA"), "0.00"))
                            Else
                                Me.TextBox26.Text = ""
                            End If


                            Me.DropDownList3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDCAUSAL")), 0, ds.Tables(0).Rows(0).Item("IDCAUSAL"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACIONES")) Then
                                Me.TextBox27.Text = ds.Tables(0).Rows(0).Item("OBSERVACIONES")
                            Else
                                Me.TextBox27.Text = ""
                            End If


                        End If
                    Case Is = 3
                        Me.Label15.Text = "Fecha Inicio de vigencia de la Garantía:"
                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False

                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.Label55.Text = ds.Tables(0).Rows(0).Item("IDPROVEEDOR")
                            Me.RadioButtonList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPODOCUMENTO")
                            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")

                            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item("NUMCONTRATO")
                            Me.TextBox4.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADISTRIBUCION"))


                            Me.DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("IDENTIDAD")
                            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item("NUMGARANTIA")
                            Me.TextBox6.Text = CStr(Format(ds.Tables(0).Rows(0).Item("MONTO"), "0.00"))
                            Me.TextBox7.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEMISION"))
                            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item("TOTALDIAS")
                            Me.Label19.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAVTO"))

                            'CARGAR FECHAS
                            Dim y As New cREGISTROGARANTIAS
                            Dim DSFECHAS As New Data.DataSet
                            DSFECHAS = y.ObtenerFechas(Request.QueryString("id"), Session("IDESTABLECIMIENTO"))
                            If DSFECHAS.Tables(0).Rows.Count > 0 Then
                                TFechas = DSFECHAS.Tables(0)
                                Me.GridView1.DataSource = DSFECHAS
                                Me.GridView1.DataBind()
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA")) Then
                                Me.TextBox15.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA"))
                            Else
                                Me.TextBox15.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI")) Then
                                Me.TextBox16.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI"))
                            Else
                                Me.TextBox16.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARECUFI")) Then
                                Me.TextBox17.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARECUFI"))
                            Else
                                Me.TextBox17.Text = ""
                            End If


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACGTIABVEOB")) Then
                                Me.TextBox19.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACGTIABVEOB"))
                            Else
                                Me.TextBox19.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPFIABUECAL")) Then
                                Me.TextBox20.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPFIABUECAL"))
                            Else
                                Me.TextBox20.Text = ""
                            End If


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA")) Then
                                Me.TextBox21.Text = CStr(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA"))
                            Else
                                Me.TextBox21.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHADEVGTIA")) Then
                                Me.TextBox24.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADEVGTIA"))
                            Else
                                Me.TextBox24.Text = ""
                            End If
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA")) Then
                                Me.TextBox25.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA"))
                            Else
                                Me.TextBox25.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VALORCUANTIA")) Then
                                Me.TextBox26.Text = CStr(Format(ds.Tables(0).Rows(0).Item("VALORCUANTIA"), "0.00"))
                            Else
                                Me.TextBox26.Text = ""
                            End If


                            Me.DropDownList3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDCAUSAL")), 0, ds.Tables(0).Rows(0).Item("IDCAUSAL"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACIONES")) Then
                                Me.TextBox27.Text = ds.Tables(0).Rows(0).Item("OBSERVACIONES")
                            Else
                                Me.TextBox27.Text = ""
                            End If


                        End If
                    Case Is = 4

                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label28.Visible = False
                        Me.TextBox13.Visible = False
                        Me.Label29.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label53.Visible = False
                        Me.TextBox26.Visible = False

                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.Label55.Text = ds.Tables(0).Rows(0).Item("IDPROVEEDOR")
                            Me.RadioButtonList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPODOCUMENTO")
                            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")

                            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item("NUMCONTRATO")
                            Me.TextBox4.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADISTRIBUCION"))


                            Me.DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("IDENTIDAD")
                            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item("NUMGARANTIA")
                            Me.TextBox6.Text = CStr(Format(ds.Tables(0).Rows(0).Item("MONTO"), "0.00"))
                            Me.TextBox7.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEMISION"))
                            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item("TOTALDIAS")
                            Me.Label19.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAVTO"))


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACTAREL")) Then
                                Me.TextBox12.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACTAREL"))
                            Else
                                Me.TextBox12.Text = ""
                            End If

                            'CARGAR FECHAS
                            Dim y As New cREGISTROGARANTIAS
                            Dim DSFECHAS As New Data.DataSet
                            DSFECHAS = y.ObtenerFechas(Request.QueryString("id"), Session("IDESTABLECIMIENTO"))
                            If DSFECHAS.Tables(0).Rows.Count > 0 Then
                                TFechas = DSFECHAS.Tables(0)
                                Me.GridView1.DataSource = DSFECHAS
                                Me.GridView1.DataBind()
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA")) Then
                                Me.TextBox15.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA"))
                            Else
                                Me.TextBox15.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI")) Then
                                Me.TextBox16.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI"))
                            Else
                                Me.TextBox16.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARECUFI")) Then
                                Me.TextBox17.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARECUFI"))
                            Else
                                Me.TextBox17.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA")) Then
                                Me.TextBox21.Text = CStr(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA"))
                            Else
                                Me.TextBox21.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHALIQUIDACION")) Then
                                Me.TextBox23.Text = CStr(ds.Tables(0).Rows(0).Item("FECHALIQUIDACION"))
                            Else
                                Me.TextBox23.Text = ""
                            End If


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHADEVGTIA")) Then
                                Me.TextBox24.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADEVGTIA"))
                            Else
                                Me.TextBox24.Text = ""
                            End If
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA")) Then
                                Me.TextBox25.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA"))
                            Else
                                Me.TextBox25.Text = ""
                            End If

                            Me.DropDownList3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDCAUSAL")), 0, ds.Tables(0).Rows(0).Item("IDCAUSAL"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACIONES")) Then
                                Me.TextBox27.Text = ds.Tables(0).Rows(0).Item("OBSERVACIONES")
                            Else
                                Me.TextBox27.Text = ""
                            End If


                        End If

                    Case Is = 5
                        Me.Label20.Visible = False
                        Me.TextBox9.Visible = False
                        Me.Label21.Visible = False

                        Me.Label22.Visible = False
                        Me.TextBox10.Visible = False
                        Me.Label23.Visible = False

                        Me.Label24.Visible = False
                        Me.TextBox11.Visible = False
                        Me.Label25.Visible = False

                        Me.Label26.Visible = False
                        Me.TextBox12.Visible = False
                        Me.Label27.Visible = False

                        Me.Label37.Visible = False
                        Me.TextBox18.Visible = False
                        Me.Label38.Visible = False

                        Me.Label39.Visible = False
                        Me.TextBox19.Visible = False
                        Me.Label40.Visible = False

                        Me.Label41.Visible = False
                        Me.TextBox20.Visible = False
                        Me.Label42.Visible = False

                        Me.Label45.Visible = False
                        Me.TextBox22.Visible = False
                        Me.Label46.Visible = False

                        Me.Label47.Visible = False
                        Me.TextBox23.Visible = False
                        Me.Label48.Visible = False

                        If ds.Tables(0).Rows.Count > 0 Then
                            Me.Label55.Text = ds.Tables(0).Rows(0).Item("IDPROVEEDOR")
                            Me.RadioButtonList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDTIPODOCUMENTO")
                            Me.DropDownList1.SelectedValue = ds.Tables(0).Rows(0).Item("IDMODALIDADCOMPRA")
                            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item("NUMPROCESO")

                            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item("NUMCONTRATO")
                            Me.TextBox4.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADISTRIBUCION"))


                            Me.DropDownList2.SelectedValue = ds.Tables(0).Rows(0).Item("IDENTIDAD")
                            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item("NUMGARANTIA")
                            Me.TextBox6.Text = CStr(Format(ds.Tables(0).Rows(0).Item("MONTO"), "0.00"))
                            Me.TextBox7.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEMISION"))
                            Me.TextBox8.Text = ds.Tables(0).Rows(0).Item("TOTALDIAS")
                            Me.Label19.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAVTO"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARECBOS")) Then
                                Me.TextBox13.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARECBOS"))
                            Else
                                Me.TextBox13.Text = ""
                            End If

                            'CARGAR FECHAS
                            Dim y As New cREGISTROGARANTIAS
                            Dim DSFECHAS As New Data.DataSet
                            DSFECHAS = y.ObtenerFechas(Request.QueryString("id"), Session("IDESTABLECIMIENTO"))
                            If DSFECHAS.Tables(0).Rows.Count > 0 Then
                                TFechas = DSFECHAS.Tables(0)
                                Me.GridView1.DataSource = DSFECHAS
                                Me.GridView1.DataBind()
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA")) Then
                                Me.TextBox15.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAACEPGTIA"))
                            Else
                                Me.TextBox15.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI")) Then
                                Me.TextBox16.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAENVIOUFI"))
                            Else
                                Me.TextBox16.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHARECUFI")) Then
                                Me.TextBox17.Text = CStr(ds.Tables(0).Rows(0).Item("FECHARECUFI"))
                            Else
                                Me.TextBox17.Text = ""
                            End If


                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA")) Then
                                Me.TextBox21.Text = CStr(ds.Tables(0).Rows(0).Item("FECHASOLDEVGTIA"))
                            Else
                                Me.TextBox21.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHADEVGTIA")) Then
                                Me.TextBox24.Text = CStr(ds.Tables(0).Rows(0).Item("FECHADEVGTIA"))
                            Else
                                Me.TextBox24.Text = ""
                            End If
                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA")) Then
                                Me.TextBox25.Text = CStr(ds.Tables(0).Rows(0).Item("FECHAEFEGTIA"))
                            Else
                                Me.TextBox25.Text = ""
                            End If

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VALORCUANTIA")) Then
                                Me.TextBox26.Text = CStr(Format(ds.Tables(0).Rows(0).Item("VALORCUANTIA"), "0.00"))
                            Else
                                Me.TextBox26.Text = ""
                            End If

                            Me.DropDownList3.Text = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("IDCAUSAL")), 0, ds.Tables(0).Rows(0).Item("IDCAUSAL"))

                            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OBSERVACIONES")) Then
                                Me.TextBox27.Text = ds.Tables(0).Rows(0).Item("OBSERVACIONES")
                            Else
                                Me.TextBox27.Text = ""
                            End If

                        End If
                End Select

            End If

        Else
            If Not Me.ViewState("TFechas") Is Nothing Then Me.TFechas = Me.ViewState("TFechas")
            If Not Me.ViewState("id") Is Nothing Then Me.ide = Me.ViewState("id")
        End If
    End Sub
    Protected Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click
        Response.Redirect("~/FrmPrincipal.aspx", False)
    End Sub
    Public Sub cargardatos()
        'tipos de documentos
        Dim c1 As New cTIPOSDOCUMENTOSCG
        Me.RadioButtonList1.DataSource = c1.ObtenerDataSetPorId()
        Me.RadioButtonList1.DataValueField = "idtipodocumento"
        Me.RadioButtonList1.DataTextField = "nombre"
        Me.RadioButtonList1.DataBind()

        'modalidades de compra
        Dim c2 As New cMODALIDADCOMPRACG
        Me.DropDownList1.DataSource = c2.ObtenerDataSetPorId
        Me.DropDownList1.DataValueField = "idmodalidadcompra"
        Me.DropDownList1.DataTextField = "nombre"
        Me.DropDownList1.DataBind()

        'entidades
        Dim c3 As New cENTIDADCG
        Me.DropDownList2.DataSource = c3.ObtenerDataSetPorId
        Me.DropDownList2.DataValueField = "identidad"
        Me.DropDownList2.DataTextField = "nombre"
        Me.DropDownList2.DataBind()

        'causales
        Dim c4 As New cCAUSALESCG
        Me.DropDownList3.DataSource = c4.ObtenerDataSetPorID3(Request.QueryString("idtg"))
        Me.DropDownList3.DataValueField = "idcausal"
        Me.DropDownList3.DataTextField = "nombre"
        Me.DropDownList3.DataBind()

        Dim t As New ListItem
        t.Text = ""
        t.Value = 0
        t.Selected = True
        Me.DropDownList3.Items.Insert(0, t)
        Me.DropDownList3.SelectedValue = 0


        'fechas
        If Request.QueryString("idtg") <> 1 Then
            CrearTablaFechas()
            Me.GridView1.DataSource = TFechas
            Me.GridView1.DataBind()
        End If

        


    End Sub

    'Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.CheckBox2.Checked Then
    '        Me.TextBox23.Enabled = False
    '        Me.TextBox23.Text = ""
    '    Else
    '        Me.TextBox23.Enabled = True
    '    End If
    'End Sub

    'Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.CheckBox1.Checked Then
    '        Me.TextBox24.Enabled = False
    '        Me.TextBox24.Text = ""
    '    Else
    '        Me.TextBox24.Enabled = True
    '    End If
    'End Sub

    'Protected Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.CheckBox3.Checked Then
    '        Me.TextBox25.Enabled = False
    '        Me.TextBox26.Enabled = False
    '        Me.TextBox25.Text = ""
    '        Me.TextBox26.Text = ""
    '    Else
    '        Me.TextBox25.Enabled = True
    '        Me.TextBox26.Enabled = True
    '    End If
    'End Sub

    'Protected Sub CheckBox4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.CheckBox4.Checked Then
    '        Me.DropDownList3.Enabled = False
    '    Else
    '        Me.DropDownList3.Enabled = True
    '    End If
    'End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label3.Visible = False
        If ddlTipoBusqueda.SelectedValue = 0 Then
            buscaPorNIT(Session("IdEstablecimiento"), Me.TextBox1.Text)
        Else
            buscaPorNombre(Session("IdEstablecimiento"), Me.TextBox1.Text)
        End If


    End Sub
    Private Sub buscaPorNombre(ByVal IDestablecimiento As Integer, ByVal nombre As String)
        Dim cprov As New cPROVEEDORESCG
        Dim ds As New Data.DataSet
        gvProveedores.Visible = True
        ds = cprov.ObtenerProveedorPorNombre(IDestablecimiento, nombre)
        If ds.Tables(0).Rows.Count = 0 Then
            Label3.Text = "NO SE ENCONTRARON REGISTROS"
            Label3.Visible = True
        Else
            gvProveedores.DataSource = ds.Tables(0)
            gvProveedores.DataBind()
            Label3.Visible = False
        End If
    End Sub
    Private Sub buscaPorNIT(ByVal IDestablecimiento As Integer, ByVal NIT As String)
        Dim cprov As New cPROVEEDORESCG
        Dim ds As New Data.DataSet
        gvProveedores.Visible = False
        ds = cprov.ObtenerProveedorPorNIT(IDestablecimiento, NIT)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Label3.Text = ""
            Me.Label55.Text = ds.Tables(0).Rows(0).Item(0)
            Me.Label4.Text = ds.Tables(0).Rows(0).Item(1)
            Me.Label5.Text = ds.Tables(0).Rows(0).Item(2)
            Me.Button4.Visible = True
            Me.Button5.Visible = True
            Me.UpdatePanel2.Visible = True
        Else
            Me.Label3.Text = "NIT no encontrado. Asegúrese que sea un NIT válido. Si es nuevo el proveedor proceda a adicionarlo en el Catálogo de Proveedores"
            Me.UpdatePanel2.Visible = False
            Me.Button4.Visible = False
            Me.Button5.Visible = False
        End If
    End Sub

    Private Sub CrearTablaFechas()

        TFechas = New Data.DataTable

        Dim ColumFechaP As New Data.DataColumn("fechapresentacion", System.Type.GetType("System.DateTime"))
        Dim ColumFechaO As New Data.DataColumn("fechaobservacion", System.Type.GetType("System.DateTime"))

        TFechas.Columns.Add(ColumFechaP)
        TFechas.Columns.Add(ColumFechaO)

        If Not Me.ViewState("TFechas") Is Nothing Then Me.ViewState.Remove("TFechas")
        Me.ViewState.Add("TFechas", TFechas)

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        TFechas.Rows.Remove(TFechas.Rows(e.RowIndex))

        If Not Me.ViewState("TFechas") Is Nothing Then Me.ViewState.Remove("TFechas")
        Me.ViewState.Add("TFechas", TFechas)

        GridView1.DataSource = TFechas
        GridView1.DataBind()

    End Sub

    Protected Sub Button2_Click1(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.GridView1.Rows.Count > 0 Then
            For Each row As GridViewRow In Me.GridView1.Rows

                Dim drFecha As Data.DataRow = TFechas.NewRow

                drFecha("fechapresentacion") = CDate(row.Cells(0).Text & " 12:00:00 AM")
                drFecha("fechaobservacion") = CDate(row.Cells(1).Text & " 12:00:00 AM")
                TFechas.Rows.Add(drFecha)
            Next
            Dim drFecha2 As Data.DataRow = TFechas.NewRow
            drFecha2("fechapresentacion") = CDate(Me.TextBox99.Text & " 12:00:00 AM")
            drFecha2("fechaobservacion") = CDate(Me.TextBox14.Text & " 12:00:00 AM")
            TFechas.Rows.Add(drFecha2)
        Else
            Dim drFecha2 As Data.DataRow = TFechas.NewRow
            drFecha2("fechapresentacion") = CDate(TextBox99.Text & " 12:00:00 AM")
            drFecha2("fechaobservacion") = CDate(Me.TextBox14.Text & " 12:00:00 AM")
            TFechas.Rows.Add(drFecha2)
        End If

        If Not Me.ViewState("TFechas") Is Nothing Then Me.ViewState.Remove("TFechas")
        Me.ViewState.Add("TFechas", TFechas)

        Me.GridView1.DataSource = TFechas
        Me.GridView1.DataBind()

        Me.TextBox99.Text = ""
        Me.TextBox14.Text = ""
        Me.RequiredFieldValidator10.Enabled = False
        Me.RequiredFieldValidator11.Enabled = False

    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("~/UACI/GARANTIAS/FrmGarantiaMO.aspx?idtg=" & Request.QueryString("idtg"))
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click

        Try
            Dim cx As New ABASTECIMIENTOS.NEGOCIO.cREGISTROGARANTIAS
            Dim x As New REGISTROGARANTIAS

            If Request.QueryString("id") Is Nothing Then
                'nuevo

                x.IDGARANTIA = 0
                x.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                x.IDTIPOGARANTIA = Request.QueryString("idtg")
                x.IDPROVEEDOR = Me.Label55.Text
                x.IDTIPODOCUMENTO = Me.RadioButtonList1.SelectedValue
                x.IDMODALIDADCOMPRA = Me.DropDownList1.SelectedValue
                x.NUMPROCESO = Me.TextBox2.Text.ToString

                If Request.QueryString("idtg") <> 1 Then
                    x.NUMCONTRATO = Me.TextBox3.Text.ToString
                    x.FECHADISTRIBUCION = Me.TextBox4.Text
                End If

                x.IDENTIDAD = Me.DropDownList2.SelectedValue
                x.NUMGARANTIA = Me.TextBox5.Text.ToString
                x.MONTO = CDec(Me.TextBox6.Text)
                x.FECHAEMISION = CDate(Me.TextBox7.Text)
                x.TOTALDIAS = CInt(Me.TextBox8.Text)
                If Me.Label19.Text <> "" Then
                    x.FECHAVTO = CDate(Me.Label19.Text)
                Else
                    If Request.QueryString("idtg") = 2 Then
                        x.FECHAVTO = CDate(Me.TextBox18.Text)
                    Else
                        Me.Label19.Text = "Falta Fecha Vencimiento"
                        Exit Sub
                    End If
                End If

                If Request.QueryString("idtg") = 2 Then
                    If Me.TextBox9.Text <> "" Then
                        x.FECHAAPRPLANUTIANT = CDate(Me.TextBox9.Text)
                    End If
                    If Me.TextBox10.Text <> "" Then
                        x.FECHAUTIPLANAVFI = CDate(Me.TextBox10.Text)
                    End If
                    If Me.TextBox11.Text <> "" Then
                        x.FECHAACEPGTIACUMCON = CDate(Me.TextBox11.Text)
                    End If
                End If
                If Request.QueryString("idtg") = 4 Then
                    If Me.TextBox12.Text <> "" Then
                        x.FECHAACTAREL = CDate(Me.TextBox12.Text)
                    End If

                End If
                If Request.QueryString("idtg") = 5 Then
                    If Me.TextBox13.Text <> "" Then
                        x.FECHARECBOS = CDate(Me.TextBox13.Text)
                    End If
                End If

                If Request.QueryString("idtg") <> 1 Then
                    If Me.TextBox15.Text <> "" Then
                        x.FECHAACEPGTIA = CDate(Me.TextBox15.Text)
                    End If
                    If Me.TextBox16.Text <> "" Then
                        x.FECHAENVIOUFI = CDate(Me.TextBox16.Text)
                    End If
                    If Me.TextBox17.Text <> "" Then
                        x.FECHARECUFI = CDate(Me.TextBox17.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 2 Then
                    If Me.TextBox18.Text <> "" Then
                        x.FECHAEJEANT = CDate(Me.TextBox18.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 3 Then
                    If Me.TextBox19.Text <> "" Then
                        x.FECHAACGTIABVEOB = CDate(Me.TextBox19.Text)
                    End If
                    If Me.TextBox20.Text <> "" Then
                        x.FECHAACEPFIABUECAL = CDate(Me.TextBox20.Text)
                    End If
                End If

                If Me.TextBox21.Text <> "" Then
                    x.FECHASOLDEVGTIA = CDate(Me.TextBox21.Text)
                End If


                If Request.QueryString("idtg") = 1 Then
                    If Me.TextBox22.Text <> "" Then
                        x.FECHARESFIRME = CDate(Me.TextBox22.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 4 Then
                    If Me.TextBox23.Text <> "" Then
                        x.FECHALIQUIDACION = CDate(Me.TextBox23.Text)
                    End If
                End If

                If Me.TextBox24.Text <> "" Then
                    x.FECHADEVGTIA = CDate(Me.TextBox24.Text)
                End If

                If Me.TextBox25.Text <> "" Then
                    x.FECHAEFEGTIA = CDate(Me.TextBox25.Text)
                End If


                If Request.QueryString("idtg") = 2 Or Request.QueryString("idtg") = 3 Then
                    If Me.TextBox26.Text <> "" Then
                        x.VALORCUANTIA = CDec(Me.TextBox26.Text)
                    End If
                End If

                If Me.DropDownList3.SelectedValue <> 0 Then
                    x.IDCAUSAL = Me.DropDownList3.SelectedValue
                End If

                x.OBSERVACIONES = Me.TextBox27.Text.ToString
                x.USUARIO = User.Identity.Name
                x.FECHA = DateTime.Now

                cx.ActualizarREGISTROGARANTIAS(x)

                Dim idgarantia As Integer = cx.ObtenerIDGarantia(Session("IdEstablecimiento"), Request.QueryString("idtg"))
                ide = idgarantia
                If Request.QueryString("idtg") <> 1 Then
                    'lo ultimo las fechas
                    If Me.GridView1.Rows.Count > 0 Then
                        For Each row As GridViewRow In Me.GridView1.Rows
                            Dim y As New cREGISTROGARANTIAS
                            y.InsertarFechas(idgarantia, Session("IDESTABLECIMIENTO"), CDate(row.Cells(0).Text & " 12:00:00 AM"), CDate(row.Cells(1).Text & " 12:00:00 AM"))
                        Next
                    End If
                End If
                Me.Button5.Enabled = True

            Else
                'edicion


                x.IDGARANTIA = Request.QueryString("id")
                x.IDESTABLECIMIENTO = Session("IdEstablecimiento")
                x.IDTIPOGARANTIA = Request.QueryString("idtg")
                x.IDPROVEEDOR = Me.Label55.Text
                x.IDTIPODOCUMENTO = Me.RadioButtonList1.SelectedValue
                x.IDMODALIDADCOMPRA = Me.DropDownList1.SelectedValue
                x.NUMPROCESO = Me.TextBox2.Text.ToString

                If Request.QueryString("idtg") <> 1 Then
                    x.NUMCONTRATO = Me.TextBox3.Text.ToString
                    x.FECHADISTRIBUCION = Me.TextBox4.Text
                End If

                x.IDENTIDAD = Me.DropDownList2.SelectedValue
                x.NUMGARANTIA = Me.TextBox5.Text.ToString
                x.MONTO = CDec(Me.TextBox6.Text)
                x.FECHAEMISION = CDate(Me.TextBox7.Text)
                x.TOTALDIAS = CInt(Me.TextBox8.Text)
                If Me.Label19.Text <> "" Then
                    x.FECHAVTO = CDate(Me.Label19.Text)
                Else
                    Me.Label19.Text = "Falta Fecha Vencimiento"
                    Exit Sub
                End If

                If Request.QueryString("idtg") = 2 Then
                    If Me.TextBox9.Text <> "" Then
                        x.FECHAAPRPLANUTIANT = CDate(Me.TextBox9.Text)
                    End If
                    If Me.TextBox10.Text <> "" Then
                        x.FECHAUTIPLANAVFI = CDate(Me.TextBox10.Text)
                    End If
                    If Me.TextBox11.Text <> "" Then
                        x.FECHAACEPGTIACUMCON = CDate(Me.TextBox11.Text)
                    End If
                End If
                If Request.QueryString("idtg") = 4 Then
                    If Me.TextBox12.Text <> "" Then
                        x.FECHAACTAREL = CDate(Me.TextBox12.Text)
                    End If

                End If
                If Request.QueryString("idtg") = 5 Then
                    If Me.TextBox13.Text <> "" Then
                        x.FECHARECBOS = CDate(Me.TextBox13.Text)
                    End If
                End If

                If Request.QueryString("idtg") <> 1 Then
                    If Me.TextBox15.Text <> "" Then
                        x.FECHAACEPGTIA = CDate(Me.TextBox15.Text)
                    End If
                    If Me.TextBox16.Text <> "" Then
                        x.FECHAENVIOUFI = CDate(Me.TextBox16.Text)
                    End If
                    If Me.TextBox17.Text <> "" Then
                        x.FECHARECUFI = CDate(Me.TextBox17.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 2 Then
                    If Me.TextBox18.Text <> "" Then
                        x.FECHAEJEANT = CDate(Me.TextBox18.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 3 Then
                    If Me.TextBox19.Text <> "" Then
                        x.FECHAACGTIABVEOB = CDate(Me.TextBox19.Text)
                    End If
                    If Me.TextBox20.Text <> "" Then
                        x.FECHAACEPFIABUECAL = CDate(Me.TextBox20.Text)
                    End If
                End If

                If Me.TextBox21.Text <> "" Then
                    x.FECHASOLDEVGTIA = CDate(Me.TextBox21.Text)
                End If


                If Request.QueryString("idtg") = 1 Then
                    If Me.TextBox22.Text <> "" Then
                        x.FECHARESFIRME = CDate(Me.TextBox22.Text)
                    End If
                End If

                If Request.QueryString("idtg") = 4 Then
                    If Me.TextBox23.Text <> "" Then
                        x.FECHALIQUIDACION = CDate(Me.TextBox23.Text)
                    End If
                End If

                If Me.TextBox24.Text <> "" Then
                    x.FECHADEVGTIA = CDate(Me.TextBox24.Text)
                End If

                If Me.TextBox25.Text <> "" Then
                    x.FECHAEFEGTIA = CDate(Me.TextBox25.Text)
                End If


                If Request.QueryString("idtg") = 2 Or Request.QueryString("idtg") = 3 Then
                    If Me.TextBox26.Text <> "" Then
                        x.VALORCUANTIA = CDec(Me.TextBox26.Text)
                    End If
                End If

                If Me.DropDownList3.SelectedValue <> 0 Then
                    x.IDCAUSAL = Me.DropDownList3.SelectedValue
                End If

                x.OBSERVACIONES = Me.TextBox27.Text.ToString
                x.USUARIO = User.Identity.Name
                x.FECHA = DateTime.Now

                cx.ActualizarREGISTROGARANTIAS(x)


                If Request.QueryString("idtg") <> 1 Then
                    'lo ultimo las fechas
                    If Me.GridView1.Rows.Count > 0 Then
                        For Each row As GridViewRow In Me.GridView1.Rows
                            Dim y As New cREGISTROGARANTIAS
                            y.InsertarFechas(Request.QueryString("id"), Session("IDESTABLECIMIENTO"), CDate(row.Cells(0).Text & " 12:00:00 AM"), CDate(row.Cells(1).Text & " 12:00:00 AM"))
                        Next
                    End If
                End If
                Me.Button5.Enabled = True
            End If

            Me.Modalpopupextender1.Show()

        Catch ex As Exception
            Me.Label56.Text = "Ha surgido un error, favor reportarlo a la Dirección de Tecnología"
        End Try
    End Sub


    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.TextBox8.Text <> "" Then

            Select Case Request.QueryString("idtg")
                Case Is = 1
                    Me.Label19.Text = Server.HtmlEncode(DateAdd(DateInterval.Day, CDec(Me.TextBox8.Text), CDate(Me.TextBox7.Text)))
                Case 2, 3
                    Me.Label19.Text = Server.HtmlEncode(DateAdd(DateInterval.Day, CDec(Me.TextBox8.Text), CDate(Me.TextBox7.Text)))
                Case Is = 4
                    'Me.Label19.Text = Server.HtmlEncode(DateAdd(DateInterval.Day, CDec(Me.TextBox8.Text), CDate(Me.TextBox13.Text)))
                    Me.Label19.Text = Server.HtmlEncode(DateAdd(DateInterval.Day, CDec(Me.TextBox8.Text), CDate(Me.TextBox7.Text)))

            End Select
        End If
    End Sub

    Protected Sub btnClose2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Modalpopupextender1.Hide()
    End Sub

    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.mdlPopup.Show()
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Reporte As ReportDocument

        Reporte = New ReportDocument
        Select Case Request.QueryString("idtg")
            Case Is = 1
                Dim reportPath As String = Server.MapPath("rptGarantia1.rpt")
                Reporte.Load(reportPath)
            Case Is = 2
                Dim reportPath As String = Server.MapPath("rptGarantia2.rpt")
                Reporte.Load(reportPath)
            Case Is = 3
                Dim reportPath As String = Server.MapPath("rptGarantia3.rpt")
                Reporte.Load(reportPath)
            Case Is = 4
                Dim reportPath As String = Server.MapPath("rptGarantia4.rpt")
                Reporte.Load(reportPath)
            Case Is = 5
                Dim reportPath As String = Server.MapPath("rptGarantia5.rpt")
                Reporte.Load(reportPath)
        End Select

        Dim cEntidad As New cREGISTROGARANTIAS
        Dim ds As Data.DataSet
        ds = cEntidad.ObtenerReporteUnaGarantia(ide, Request.QueryString("idtg"), Session("IdEstablecimiento"))
        Reporte.SetDataSource(ds.Tables(0))


        Select Case Me.DropDownList99.SelectedValue
            Case Is = 0
                Reporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, True, "Reporte")
            Case Is = 1
                Reporte.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, True, "Reporte")
            Case Is = 2
                Reporte.ExportToHttpResponse(ExportFormatType.Excel, Response, True, "Reporte")
        End Select


        Me.mdlPopup.Hide()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.mdlPopup.Hide()

    End Sub

    Protected Sub gvProveedores_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvProveedores.SelectedIndexChanged
        buscaPorNIT(Session("IDEstablecimiento"), gvProveedores.SelectedRow.Cells(2).Text)
    End Sub
End Class
