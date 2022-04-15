$(document).ready(function () {

    let selectPure;

    $("form").submit(function () {
        $("#alunosBanca").val(selectPure._config.value);
        return true;
    });

    $("#CursoId").change(function () {
        getAlunos();
    });

    getAlunos();

    function getAlunos() {
        let cursoId = $("#CursoId option:selected").val();
        if (cursoId) {
            $.getJSON("/Banca/GetAlunos?cursoId=" + cursoId, function (data) {
                initSelectPure(data);
            });
        }
        else {
            initSelectPure([]);
        }
    }

    function initSelectPure(options) {

        let values = [];
        let alunosBanca = $("#alunosBanca").val();

        if (alunosBanca.length > 0) {
            values = alunosBanca.split(",");
        }

        $("#select-pure").html("");

        selectPure = new SelectPure("#select-pure", {
            options: options,
            autocomplete: true,
            multiple: true,
            value: values,
            icon: "fa fa-times"
        });
    }
});