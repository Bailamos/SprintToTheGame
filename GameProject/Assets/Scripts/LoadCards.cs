using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class LoadCards : MonoBehaviour
{
    public class cardProperties
    {
        public string nazwa;
        public int atak;
        public int obrona;

        public cardProperties(string n, string a, string o)
        {
            this.nazwa = n;
            this.atak = int.Parse(a);
            this.obrona = int.Parse(o);
        }
    }

    public List<cardProperties> Deck;

    // Use this for initialization
    void Start()
    {
        string filePath = Application.dataPath;

        Deck = new List<cardProperties>();
        XmlDocument doc = new XmlDocument();

        if (File.Exists(filePath + "\\XML\\karty.xml"))
        {
            doc.Load(filePath + "\\XML\\karty.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                Deck.Add(new cardProperties(node["Title"].InnerText, node["Atak"].InnerText, node["Obrona"].InnerText));
            }
        }
    }

}
