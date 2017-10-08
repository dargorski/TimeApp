Ext.define('TrainTimetableApp.view.StationGrid', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.StationGrid',
    initComponent: function () {

        var self = this;

        this.id = "stationGrid";
        this.minHeight = 222;
        this.store = "TrainTimetableApp.store.StationStore";

        var rowEditing = Ext.create('Ext.grid.plugin.RowEditing', {
            clicksToMoveEditor: 1,
            autoCancel: false
        });

        this.plugins = [rowEditing];

        this.columns = [
            {
                header: 'Station',
                dataIndex: 'station',
                flex: 4,
                editor: {
                    allowBlank: true
                }
            },
            {
                header: 'Arrival time',
                dataIndex: 'arrivalTime',
                flex: 2,
                editor: {
                    allowBlank: true
                }
            },
            {
                header: 'Departure time',
                dataIndex: 'departureTime',
                flex: 2,
                editor: {
                    allowBlank: true
                }
            },
            {
                xtype: 'actioncolumn',
                header: 'Delete',
                width: 150,
                align: 'center',
                items: [
                    {
                        icon: '/app/images/delete.png',
                        handler: function (grid, rowIndex, colIndex, item, e, record) {
                            grid.getStore().remove(record);
                        },
                        scope: this
                    }
                ]
            }
        ];

        this.tbar = [
            {
                xtype: 'button',
                text: 'Add new item',
                handler: function () {
                    rowEditing.cancelEdit();

                    var newRecord = Ext.create("TrainTimetableApp.model.StationModel", {});
                    var rowNumber = self.store.getCount();
                    self.store.insert(rowNumber, newRecord);
                    rowEditing.startEdit(rowNumber, 0);

                }
            },
            {
                xtype: 'button',
                text: 'Clear items',
                handler: function () {
                    rowEditing.cancelEdit();
                    self.store.removeAll();
                }
            }
        ]

        this.callParent(arguments);
    }
});