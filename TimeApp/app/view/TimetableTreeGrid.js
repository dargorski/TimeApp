Ext.define('TrainTimetableApp.view.TimetableTreeGrid', {
    extend: 'Ext.tree.Panel',
    alias: 'widget.TimetableTreeGrid',
    initComponent: function () {

        this.id = "trainConnectionGrid";
        this.title = 'Routes timetable';
        this.reserveScrollbar = true;
        this.collapsible = true;
        this.loadMask = true;
        this.useArrows = true;
        this.rootVisible = false;
        this.store = "TrainTimetableApp.store.TimetableTreeStore";
        this.animate = false;

        this.columns = [{
            xtype: 'treecolumn',
            text: 'Name',
            flex: 2.5,
            dataIndex: 'TrainName'
        }, {
            text: 'Route',
            flex: 2,
            dataIndex: 'Route',
        }, {
            text: 'Type',
            flex: 2,
            dataIndex: 'Type'
        }, {
            text: 'Station',
            flex: 3,
            dataIndex: 'Station'
        }, {
            text: 'Arrival time',
            flex: 4,
            dataIndex: 'ArrivalTime'
        }, {
            text: 'Departure time',
            flex: 5,
            dataIndex: 'DepartureTime'
        },
        {
            xtype: 'actioncolumn',
            header: 'Delete',
            width: 150,
            align: 'center',
            items: [{
                icon: '/app/images/delete.png',
                handler: function (grid, rowIndex, colIndex,
                    item, e, record) {
                    record.parentNode.removeChild(record);
                },

                getClass: function (v, meta, rec) {
                    if (rec.data["TrainName"] == undefined) {
                        return "x-hidden-display";
                    }
                },
                scope: this
            }]
        }

        ]

        this.callParent(arguments);
    }
});