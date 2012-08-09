using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using CQG;

namespace TickNet
{
    public static class QueryBuilder
    {
 
        public static String createTable(String TableName)
        {
            String q = "CREATE TABLE `"+TableName+"` (";
            q+="`index_id` int(10) NOT NULL AUTO_INCREMENT,";
            q+="`symbol` varchar(20) DEFAULT NULL,";
            q += "`depth` int(10) DEFAULT 0,";
            q += "`DOMBid` float(9,3) DEFAULT NULL,";
            q += "`DOMAsk` float(9,3) DEFAULT NULL,";
            q+="`DOMBidVol` int(10) DEFAULT NULL,";
            q+="`DOMAskVol` int(10) DEFAULT NULL,";
            q += "`Trade` float(9,3) DEFAULT NULL,";
            q+="`TradeVol` int(10) DEFAULT NULL,";
            q += "IsNewTrade boolean,";
            q+="`ts` varchar(30) DEFAULT 'no timestamp',";
            q += "`GroupID` int(10),";
            q+="PRIMARY KEY (`index_id`))";
            return q;
        }
        public static String InsertData(String TableName,CQGInstrument instrument,int depth,uint groupID,bool isNew)
        {
            String symbol = instrument.FullName;
            String query = "INSERT INTO `" + TableName + "`";
            query += "(`symbol`,`depth`,`DOMBid`,`DOMAsk`,`DOMBidVol`,`DOMAskVol`,`Trade`,`TradeVol`,`IsNewTrade`,`ts`,GroupID)";
            String runQuery = "";
            int BalancedDepth = (instrument.DOMAsks.Count < instrument.DOMBids.Count)
                                    ? instrument.DOMAsks.Count
                                    : instrument.DOMBids.Count;
            for (int index = 0; ((index < BalancedDepth) && (index < depth)); index++)
            {
                //query += "(`symbol`,`depth`,`DOMBid`,`DOMAsk`,`DOMBidVol`,`DOMAskVol`,`Trade`,`TradeVol`,`ts`)";
                CQGQuote DOMAsk = instrument.DOMAsks[index];
                CQGQuote DOMBid = instrument.DOMBids[index];
                runQuery += query + " VALUES('" + symbol + "'," + Convert.ToString(index+1) + ",";
                runQuery += DOMBid.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += DOMAsk.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += DOMBid.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += DOMAsk.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += instrument.Trade.Price.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += instrument.Trade.Volume.ToString("G", CultureInfo.InvariantCulture) + ",";
                runQuery += "" + isNew + ",";
                runQuery += "'" + instrument.Timestamp.ToString("yyyy-MM-dd hh:mm:ss fff") + "',";
                runQuery += Convert.ToString(groupID) + ");";
            }
            //instrument.
            return runQuery;
        }
        public static String getReorderRequest(String TableName)
        {
            String T_Name = TableName + "_s";
            String query = "CREATE TABLE `" + T_Name + "` LIKE `" + TableName + "`;";
            query += "INSERT INTO `" + T_Name + "` SELECT * FROM `" + TableName + "` ORDER BY `groupID`;";
            query += "COMMIT;";
            query += "DROP TABLE `" + TableName + "`;";
            query += "ALTER TABLE `" + T_Name + "` RENAME TO `" + TableName + "`;";
            return query;
        }
    }
}
