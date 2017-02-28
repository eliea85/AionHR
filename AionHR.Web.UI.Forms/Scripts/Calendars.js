﻿
var editRender = function () {
    return '<img class="imgEdit" style="cursor:pointer;" src="Images/Tools/edit.png" />';
};

var deleteRender = function () {
    return '<img class="imgDelete"  style="cursor:pointer;" src="Images/Tools/delete.png" />';
};
var attachRender = function () {
    return '<img class="imgAttach"  style="cursor:pointer;" src="Images/Tools/attach.png" />';
};
//Ext.apply(Ext.form.VTypes, {
//    numberrange: function (val, field) {
//        if (!val) {
//            return;
//        }

//        if (field.startNumberField && (!field.numberRangeMax || (val != field.numberRangeMax))) {
//            var start = Ext.getCmp(field.startNumberField);

//            if (start) {
//                start.setMaxValue(val);
//                field.numberRangeMax = val;
//                start.validate();
//            }
//        } else if (field.endNumberField && (!field.numberRangeMin || (val != field.numberRangeMin))) {
//            var end = Ext.getCmp(field.endNumberField);

//            if (end) {
//                end.setMinValue(val);
//                field.numberRangeMin = val;
//                end.validate();
//            }
//        }

//        return true;
//    }
//});
function addEmployee() {
    
    var breaksGrid = App.breaksGrid,
        store = breaksGrid.getStore();
    
    breaksGrid.editingPlugin.cancelEdit();

    store.getSorters().removeAll();
    breaksGrid.getView().headerCt.setSortState(); // To update columns sort UI
    
    store.insert(0, {
        name: 'new break',
        start: '9:00',
        end: '10:00',
        isBenifit: false
       
    });

    breaksGrid.editingPlugin.startEdit(0, 0);
}
function addBreak() {

    var periodsGrid = App.periodsGrid,
        store = periodsGrid.getStore();

    periodsGrid.editingPlugin.cancelEdit();

    store.getSorters().removeAll();
    periodsGrid.getView().headerCt.setSortState(); // To update columns sort UI

    store.insert(0, {
        name: 'new break',
        start:null,
        end:null,
        isBenifit: false

    });

    periodsGrid.editingPlugin.startEdit(0, 0);
}

function removeBreak() {

    var periodsGrid = App.periodsGrid,
        sm = periodsGrid.getSelectionModel(),
        store = periodsGrid.getStore();

    periodsGrid.editingPlugin.cancelEdit();
    store.remove(sm.getSelection());

    if (store.getCount() > 0) {
        sm.select(0);
    }
}
function removeEmployee() {
    
    var breaksGrid = App.breaksGrid,
        sm = breaksGrid.getSelectionModel(),
        store = breaksGrid.getStore();

    breaksGrid.editingPlugin.cancelEdit();
    store.remove(sm.getSelection());

    if (store.getCount() > 0) {
        sm.select(0);
    }
}

function getTimeZone()
{
   
    var d = new Date();
    
    
    var n = d.getTimezoneOffset();
    
    document.getElementById("timeZoneOffset").setAttribute("text", n / 60);
    s = n / 60;
    App.direct.StoreTimeZone(s);
   

}
var cellClick = function (view, cell, columnIndex, record, row, rowIndex, e) {

    CheckSession();

    
    
    var t = e.getTarget(),
        columnId = this.columns[columnIndex].id; // Get column id
    
    if (t.className == "imgEdit" && columnId == "colEdit") {
        //the ajax call is allowed

        return true;
    }

    if (t.className == "imgDelete" && columnId == "colDelete") {
        //the ajax call is allowed
        return true;
    }
    if (t.className == "imgAttach" && columnId == "colAttach") {
        //the ajax call is allowed
        return true;
    }
    if (columnId == "ColName" || columnId == "colDetails" || columnId == "colDayName" || columnId == "colYearDetails")
    {
        
        return true;
    }
        


    //forbidden
    return false;
};


var getCellType = function (grid, rowIndex, cellIndex) {
   
    var columnId = grid.columns[cellIndex].id; // Get column id
    return columnId;
};


var enterKeyPressSearchHandler = function (el, event) {

    var enter = false;
    if (event.getKey() == event.ENTER) {
        if (el.getValue().length > 0)
        { enter = true; }
    }

    if (enter === true) {
        App.Store1.reload();
    }
};
function getDay(dow)
{
  
    switch(dow)
    {
        case 1: return "sunday";
        case 2: return "mmonday";
        case 3: return "tuesday";
        case 4: return "wednesday";
        case 5: return "thursday";
        case 6: return "friday";
        case 7: return "saturday";
    }
}
$(document).ready(function () {
    $("#tbCalendar td").click(function () {
        
        if (!$(this).hasClass('notexist')) {
            currentDayId = $(this).find('.hidden:first').html();

            App.direct.OpenDayConfig(currentDayId);
        }
    });
});
