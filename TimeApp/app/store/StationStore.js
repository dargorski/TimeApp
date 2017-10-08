Ext.define('TrainTimetableApp.store.StationStore', {
    extend: 'Ext.data.Store',
    autoDestroy: true,
    model: 'TrainTimetableApp.model.StationModel',
    proxy: {
        type: 'memory'
    },
    data: []
});