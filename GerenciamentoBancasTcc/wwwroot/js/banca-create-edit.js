$(document).ready(function () {

    let selectPure;

    $("form").submit(function () {
        $("#alunosBanca").val(selectPure._config.value);
        return true;
    });

    $("#CursoId").change(function () {
        getTurmas();
        initSelectPure([]);
    });

    $("#TurmaId").change(function () {
        getAlunos();
    });

    initSelectPure([]);

    function getAlunos() {
        let turmaId = $("#TurmaId option:selected").val();
        if (turmaId) {
            $.getJSON("/Banca/GetAlunos?turmaId=" + turmaId, function (data) {
                initSelectPure(data);
            });
        }
        else {
            initSelectPure([]);
        }
    }

    function getTurmas() {
        $("#TurmaId").html("");
        let cursoId = $("#CursoId option:selected").val();
        if (cursoId) {
            $.getJSON("/Banca/GetTurmas?cursoId=" + cursoId, function (data) {
                $("#TurmaId").append('<option value=""></option>');
                for (let i = 0; i < data.length; i++) {
                    $("#TurmaId").append(`<option value="${data[i].value}">${data[i].label}</option>`);
                }
            });
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