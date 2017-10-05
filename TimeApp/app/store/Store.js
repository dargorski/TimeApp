Ext.define('TrainTimetableApp.store.TimetableTreeStore', {
    extend: 'Ext.data.TreeStore',
    model: 'TrainTimetableApp.model.TimetableTreeModel',
    proxy: {
        type: 'rest',
        reader: 'json',
        url: '/api/TrainConnections',
        batchActions: true,
        appendId: false
    },
    lazyFill: false
});