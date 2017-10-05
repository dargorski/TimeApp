Ext.define('TrainTimetableApp.model.TimetableTreeModel', {
    extend: 'Ext.data.TreeModel',
    idProperty: 'TrainId',
    fields: [
        {
            name: "TrainName"
        },
        {
            name: "Route"
        },
        {
            name: "Type"
        },
        {
            name: "Station"
        },
        {
            name: "ArrivalTime"
        },
        {
            name: "DepartureTime"
        }
    ]
});