
$(function () {
    var form;
    $('#file').change(function (event) {
        form = new FormData();
        form.append('file', event.target.files[0]);        
    });

    $('#btn-uploadfile').click(function (e) {
        e.preventDefault();
        $.ajax({
            url: 'http://localhost:50302/api/Arquivo/Converter',
            data: form,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                saveTextInFile(data);
                $('#alertaInfo').show();
                setTimeout("location.reload();", 10000);                
            },
            error: function (data) {
                $('#alertaDanger').show();
                setTimeout("$('#alertaDanger').hide();", 10000);
            }
        });
    });
});

function saveTextInFile(text){
    var blob = new Blob([text], {type: "text/csv;charset=utf-8"});
    saveAs(blob, "arquivoconvertido.csv");    
}