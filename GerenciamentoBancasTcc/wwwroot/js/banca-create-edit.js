$(document).ready(function () {

    let selectPure;

    $("#CursoId").change(function () {
        getTurmas();
        initSelectPure([]);
    });

    $("#TurmaId").change(function () {
        getAlunos();
    });

    getAlunos();

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

    //$('#date-picker').mobiscroll().datepicker({
    //    controls: ['calendar'],
    //    selectMultiple: true,
    //    selectMin: 1,
    //    selectCounter: true
    //});

    let html = $('#datetime-container').html();

    $('#btn-add').click(function () {
        $('#datetime-container').append(html);
    });

    $("#btn-cadastrar").click(function () {

        let datetimes = [];

        $('.datetime-row').each(function () {
            let date = $(this).find('input').val();
            if (date) {
                datetimes.push(date + ' ' + $(this).find('select').val());
            }
        });

        $.ajax({
            type: "POST",
            url: "/Banca/Create",
            data: {
                TurmaId: $("#TurmaId").val(),
                Tema: $("#TemaId").val(),
                UsuarioId: $("#UsuarioId").val(),
                Sala: $("#SalaId").val(),
                Descricao: $("#DescricaoId").val(),
                QtdProfBanca: $("#QtdProfBancaId").val(),
                alunosBanca: selectPure._config.value,
                possiveisDiasParaBanca: datetimes
            },

            success: function (data) {
                window.location.replace("https://localhost:5001/Banca");
            }
        });
    });
});