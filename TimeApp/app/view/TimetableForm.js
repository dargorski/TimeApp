Ext.define('TrainTimetableApp.view.TimetableForm', {
    extend: 'Ext.Component',
    alias: 'widget.TimetableForm',
    width: 280,
    padding: 15,
    id: 'test',
    html: [
        "<form>" +
        "<fieldset>" +
        "<legend>Basic route data:</legend>" +
        "<table style='width:100%; height: 200px;'>" +
        "<tr><td>Name:</td><td><input data-bind='value: name' type='text' style='width:100%'></td></tr>" +
        "<tr><td>Start station:</td><td><input data-bind='value: startStation' type='text' style='width:100%'></td></tr>" +
        "<tr><td>End station:</td><td><input data-bind='value: endStation' type='text' style='width:100%'></td></tr>" +
        "<tr><td>Type:</td><td><select data-bind='value: type' style='width:100%'><option>InterCity</option><option>Pendolino</option><option>Regio</option></select></td></tr>" +
        "<tr><td colspan='2' style='text-align:center; padding:10px;'><input type='button' value='Save' data-bind='click: save'>&nbsp;&nbsp;<input type='button' value='Clear' data-bind='click: clear'></td></tr>" +
        "</table>" +
        "</fieldset>" +
        "</form>"
    ],
    onRender: function () {

        var viewModel = {
            name: ko.observable(),
            startStation: ko.observable(),
            endStation: ko.observable(),
            type: ko.observable(),
            save: function () {

                var data = { "Name": this.name(), "Start": this.startStation(), "Destination": this.endStation(), "ConnectionType": this.type() };

                var stationList = [];
                var stationGrid = Ext.getCmp("stationGrid");
                stationGrid.getStore().each(function (record) {
                    var station = { "Name": record.data["station"], "ArrivalTime": record.data["arrivalTime"], "DepartureTime": record.data["departureTime"] };
                    stationList.push(station);
                });
                data.Stations = stationList;

                var self = this;

                $.post("api/TrainConnections", data)
                    .done(function (msg) {
                        self.clear();
                        var stationGrid = Ext.getCmp("stationGrid");
                        stationGrid.getStore().removeAll();

                        var trainConnectionGrid = Ext.getCmp("trainConnectionGrid");
                        trainConnectionGrid.getStore().load();


                    })
                    .fail(function (xhr, status, error) {
                        var message = "";
                        var modelState = xhr.responseJSON.ModelState;
                        for (var property in modelState) {
                            if (modelState.hasOwnProperty(property)) {
                                var errorMessage = modelState[property][0];
                                message += (errorMessage + "<br>");
                            }
                        }
                        Ext.MessageBox.alert('Error', message);
                    });

            },
            clear: function () {
                this.name(undefined);
                this.startStation(undefined);
                this.endStation(undefined);
                this.type("InterCity");
            }
        }
        ko.applyBindings(viewModel);

        this.callParent();
    }
});