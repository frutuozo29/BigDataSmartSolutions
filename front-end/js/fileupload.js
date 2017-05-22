$(function () {
    var form;
    $('#file').change(function (event) {
        form = new FormData();
        form.append('file', event.target.files[0]); // para apenas 1 arquivo
        //var name = event.target.files[0].content.name; // para capturar o nome do arquivo com sua extenção
    });

    $('#btn-uploadfile').click(function (e) {
        //e.preventDefault();
        console.log(form);
        $.ajax({
            url: 'http://localhost:50302/api/Arquivo/Converter', // Url do lado server que vai receber o arquivo
            data: form,
            processData: false,
            contentType: "multipart/form-data",
            type: 'POST',
            //success: function (data) {
                
            //},
            //error: function (data) {
            //    alert(data.Message);
            //}
        });
    });
});