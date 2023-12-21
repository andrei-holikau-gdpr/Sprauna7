// https://learn.microsoft.com/ru-ru/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet?view=aspnetcore-7.0

window.jsAlert = (message) => {
    alert(message);
}

window.jsCheckSpNotAuthorized = (message) => {
    var elementSpNotAuthorized = document.getElementById('SpNotAuthorized');
    if (elementSpNotAuthorized == undefined) {
        alert(message);
    }
}


window.setMask = () => {
    var phoneMask = IMask(
        document.getElementById('ContactNumber'), {
        mask: '+000 (00) 000-00-00'
    });
};

window.onClickloadAllProductSp = () => {
    document.getElementById("loadAllProductSp").click();
};

window.showModalUnit = () => {
    document.getElementById("modDialog").modal('show');
};

window.ModalBtnCloseOnClick = () => {
    console.log("window.ModalBtnCloseOnClick");
    document.querySelector("#PackagesModal .btn-close").click();
}

window.InitialiseTable = () => {


    var spDataTable = $('#example');
    if (spDataTable !== undefined) {
        spDataTable.DataTable({
            language: {
                lengthMenu: 'Показать _MENU_ записей на странице',
                zeroRecords: 'Ничего не найдено - извините',
                info: 'Показана страница _PAGE_ из _PAGES_<br/>',
                infoEmpty: 'Нет доступных записей',
                infoFiltered: '(отфильтровано из _MAX_ записей)',
                search: 'Поиск: ',
                paginate: {
                    "first": "Первая",
                    "last": "Последняя",
                    "next": "Следующая",
                    "previous": "Предыдущая"
                },

            },
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'colvis',
                    text: 'Колонки'
                },
                /*'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'*/
            ],
            keys: true,
            scrollY: 300,
            select: {
                items: 'row'
            },
            colReorder: true,
        });
    } 

    //new $.fn.dataTable.Responsive(table, {
    //    details: $.fn.dataTable.Responsive.display.childRowImmediate
    //});
}


window.DataTablesRemove = () => {    
    var TableExample = $('#example');
    if (TableExample != undefined) {
        $('#example').DataTable().destroy();

        // var exampleTable = document.querySelector("#table");
        // var divForTable = document.querySelector(".div-for-table");
        // divForTable.removeChild(exampleTable);

        // Removes the datatable wrapper from the dom.
        var divForTable = document.querySelector('div-for-table'); // ( table +  _wrapper');
        if (divForTable != undefined) {
            divForTable.parentNode.removeChild(TableExample);
        }
    }
}

function TestJQuery() {
    if (window.jQuery) {
        // jQuery is loaded
        alert("JQuery is working!");
    } else {
        // jQuery is not loaded
        alert("JQuery Doesn't Work");
    }
}


window.GradientMouse = () => {
    document.addEventListener('mousemove', e => {
        const x = e.clientX;
        const y = e.clientY;
        document.body.style.background = `radial-gradient(circle at ${x}px ${y}px, #D9EDFE, #EEF7FF)`;
    });
}

window.scrollToTop = function () {
    location.reload();
    //window.scrollTo(0, 0);
}

window.triggerFileDownload = (fileName, url) => {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}

window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.target = '_blank';
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    console.log(anchorElement);
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

window.jsReloadPage = () => {
    location.reload();
}

