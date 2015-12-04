using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System;



public class LoadCards : MonoBehaviour
{

    public class cardProperties
    {
        public string nazwa;
        public int atak;
        public int obrona;
        public int like;
        public int tweet;
        public int snap;
        public string opis;
        public string typ;

        public cardProperties(string n, string a, string o, string l, string t, string s, string op, string ty)
        {
            this.nazwa = n;
            this.atak = int.Parse(a);
            this.obrona = int.Parse(o);
            this.like = int.Parse(l);
            this.tweet = int.Parse(t);
            this.snap = int.Parse(s);
            this.opis = op;
            this.typ = ty;
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
                Deck.Add(new cardProperties(node["Title"].InnerText, node["Atak"].InnerText, node["Obrona"].InnerText, node["Like"].InnerText, node["Snap"].InnerText, node["Tweet"].InnerText, node["Opis"].InnerText, node["Typ"].InnerText));
            }
        }
    }

}
