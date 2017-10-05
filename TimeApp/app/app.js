Ext.application({
    name: 'TrainTimetableApp',
    appFolder: 'app',
    autoCreateViewport: true,
    stores: ['TrainTimetableApp.store.TimetableTreeStore',
        'TrainTimetableApp.store.StationStore']
});

