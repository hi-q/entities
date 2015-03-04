$("#products-grid").jqGrid({
    url: "Products/PageAsync",
    datatype: "json",
    mtype: "POST",
    colNames: ["Serial Number", "Description"],
    colModel: [
        {
            key: true,
            name: "SerialNumber",
            editable: true
        },
        {
            name: "Description",
            editable: true
        }
    ],
    prmNames: {
        page: "page",
        rows: "rowNum"
    },
    pager: $("#products-pager"),
    rowNum: 10,
    height: "100%",
    width: "640px",
    shrinkToFit: false,
    emptyRecords: "No records",
    caption: "Products",
    multiselect: true,
    jsonReader: {
        root: "Items",
        page: "PageNum",
        total: "Total",
        records: "Rows"
    }
}).navGrid("#products-pager", {
    edit: true,
    add: true,
    del: true,
    search: true,
    refresh: true
}, {
    //edit
    url: "ExploitedProducts/ExploitAsync"
}, {
    //add
    url: "Products/Add"
}, {
    //delete
    url: "Products/DeleteAsync"
});