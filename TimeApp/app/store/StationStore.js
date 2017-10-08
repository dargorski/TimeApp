Ext.define('TimeApp.store.StationStore', {
    extend: 'Ext.data.Store',
    autoDestroy: true,
    model: 'TimeApp.model.StationModel',
    proxy: {
        type: 'memory'
    },
    data: []
});