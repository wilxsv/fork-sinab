<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Uploader.ascx.vb" Inherits="Controles_Uploader" %>
<h2>Agregar Especificación Técnicas </h2>
<p>Se permiten lo siguientes tipos de archivo con extención: odt, ods, doc, docx, xls, xlsx, pdf.</p>

<asp:Panel runat="server" ID="popUpload" CssClass="fileupload-buttonbar">
    <div class="fileupload-buttons">
        <span class="fileinput-button">
            <span class="fileUploadContainer">Agregar Archivos...</span>
            <input id="fileupload" type="file" name="files[]" multiple="multiple" />
        </span>
        <span class="fileupload-process"></span>
    </div>

    <div class="fileupload-progress fade" style="display: none">
        <!-- The global progress bar -->
        <div class="progress" style="background-color: green" role="progressbar" aria-valuemin="0" aria-valuemax="100"></div>
        <!-- The extended global progress state -->
        <div class="progress-extended">&nbsp;</div>
    </div>
    <div class=".lblWrongExtension"></div>
    <div class="fileupload-end"></div>
</asp:Panel>
<script type="text/javascript">
    $(function () {
        $('#fileupload').fileupload({
            replaceFileInput: false,
            dataType: 'json',
            url: '<%= ResolveUrl(String.Format("~/AjaxFileHandler.ashx?solicitud={0}&establecimiento={1}&producto={2}&renglon={3}", IdSolicitud, IdEstablecimiento, IdProducto, Renglon))%>',
                add: function (e, data) {
                    $('.fileupload-end').html("");
                    $('.lblWrongExtension').css("display", "none");
                    var valid = true;
                    var re = /^.+\.((pdf)|(doc)|(docx)|(odt)|(xls)|(xlsx))$/i;
                    if (data.files) {
                        $.each(data.files, function (index, file) {
                            if (!re.test(file.name)) {
                                $(".lblWrongExtension").css("display", "");
                                valid = false;
                            }
                        });
                    }
                    data.renglon = 32;
                    if (valid) {

                        $('<p/>').text('Subiendo al servidor...').appendTo('.fileupload-end');
                        data.submit();

                    }
                },
                progressall: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('.progress').show().css(
                        'width',
                        progress + '%'
                    );
                },
                done: function (e, data) {
                    if (data.result.name) {
                        $('.fileupload-end').empty();
                        $('<p/>').text('Archivo guardado en el servidor como:' + data.result.name).appendTo('.fileupload-end');
          
                    }
                    
                }
            });
 });

</script>

<script id="template-upload" type="text/x-tmpl">
{% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-upload fade">
        <td>
            <span class="preview"></span>
        </td>
        <td>
            <p class="name">{%=file.name%}</p>
            <strong class="error"></strong>
        </td>
        <td>
            <p class="size">Processing...</p>
            <div class="progress"></div>
        </td>
        <td>
            {% if (!i && !o.options.autoUpload) { %}
                <button class="start" disabled>Start</button>
            {% } %}
            {% if (!i) { %}
                <button class="cancel">Cancel</button>
            {% } %}
        </td>
    </tr>
{% } %}
</script>

<script id="template-download" type="text/x-tmpl">
{% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-download fade">
        <td>
            <span class="preview">
                {% if (file.thumbnailUrl) { %}
                    <a href="{%=file.url%}" title="{%=file.name%}" download="{%=file.name%}" data-gallery><img src="{%=file.thumbnailUrl%}"></a>
                {% } %}
            </span>
        </td>
        <td>
            <p class="name">
                <a href="{%=file.url%}" title="{%=file.name%}" download="{%=file.name%}" {%=file.thumbnailUrl?'data-gallery':''%}>{%=file.name%}</a>
            </p>
            {% if (file.error) { %}
                <div><span class="error">Error</span> {%=file.error%}</div>
            {% } %}
        </td>
        <td>
            <span class="size">{%=o.formatFileSize(file.size)%}</span>
        </td>
        <td>
            <button class="delete" data-type="{%=file.deleteType%}" data-url="{%=file.deleteUrl%}"{% if (file.deleteWithCredentials) { %} data-xhr-fields='{"withCredentials":true}'{% } %}>Delete</button>
            <input type="checkbox" name="delete" value="1" class="toggle">
        </td>
    </tr>
{% } %}
</script>
