$(document).ready(function () {

    let selectPure;

    function init() {
        getAlunos();
        let datasBanca = $("#datasBanca").val();
        if (datasBanca && datasBanca.length > 0) {
            datasBanca.split(",").forEach(function (item) {
                let datetime = item.split(' ');
                addDateTime(datetime[0], datetime[1]);
            });
        }
    }

    $("form").submit(function () {
        
        let datetimes = [];

        $('.datetime-row').each(function () {
            let date = $(this).find('input').val();
            if (date) {
                datetimes.push(date + ' ' + $(this).find('select').val());
            }
        });

        $("#datasBanca").val(datetimes);
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

        if (options && alunosBanca && alunosBanca.length > 0) {
            alunosBanca.split(",").forEach(function (item) {
                if (options.find(option => { return option.value === item })) {
                    values.push(item);
                }
            });            
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

    $('#btn-add').click(function () {
        addDateTime();
    });

    function addDateTime(date, time) {
        let id = Math.random().toString().replace('.', '');
        let html =
            `<div id="${id}" class="row datetime-row">
                <div class="col-md-3">
                    <div class="input-group mb-3">
                        <input type="date" class="form-control possiveis-datas" value="${date ? date : ''}" />
                        <span class="text-danger"></span>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="input-group mb-3">
                        <select class="form-select">
                            <option ${time === '19:00' ? 'selected="selected"' : ''} value="19:00">19:00</option>
                            <option ${time === '20:00' ? 'selected="selected"' : ''} value="20:00">20:00</option>
                            <option ${time === '21:00' ? 'selected="selected"' : ''} value="21:00">21:00</option>
                        </select>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="input-group mb-3">
                        <a href="javascript:$('#${id}').remove()" class="btn btn-danger"><i class="fa fa-trash-o"></i></a>
                    </div>
                </div>
            </div>`;

        $('#datetime-container').append(html);

        var today = new Date().toISOString().split('T')[0];
        $(".possiveis-datas").attr('min', today);
    }

    init();
});