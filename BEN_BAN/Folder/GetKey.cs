using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_NGAN_HANG
{
    internal class GetKey
    {
        static MongoClient mongoClient = new MongoClient();
        static IMongoDatabase dbKey = mongoClient.GetDatabase("keyDB");
        static IMongoCollection<Key> collectionkey = dbKey.GetCollection<Key>("key");
        public static string get_PRIVATEKEY_BEN_BAN()
        {
            try
            {
                string id = "6479994ed90f01e7ea4b792f";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static string get_PUBLICKEY_BEN_MUA()
        {
            try
            {
                string id = "64812bd9587911d0097a4311";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /*public static string get_PRIVATEKEY_BEN_MUA()
        {
            try
            {
                string id = "64812c21587911d0097a4312";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }*/
        public static string get_PUBLICKEY_BEN_VAN_CHUYEN()
        {
            try
            {
                string id = "64812b8a587911d0097a430f";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /*public static string get_PRIVATEKEY_BEN_VAN_CHUYEN()
        {
            try
            {
                string id = "64812bb6587911d0097a4310";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }*/

        public static string get_PUBLICKEY_BEN_BAN()
        {
            try
            {
                string id = "6479b264d90f01e7ea4b7930";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static string get_PUBLICKEY_BEN_NGAN_HANG()
        {
            try
            {
                string id = "6479b2d1d90f01e7ea4b7932";
                var filterDefinition = Builders<Key>.Filter.Eq(a => a._id, id);
                var product = collectionkey.Find(filterDefinition).FirstOrDefault();
                return (product.value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}
