using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace KomplexneSiete
{
    public class Export
    {
        private void write_nodes(XmlTextWriter writer, List<Node> nodes)
        {
            for (int i = 0; i < nodes.Count(); i++) {
                writer.WriteStartElement("node");
                writer.WriteAttributeString("", "id", "", "n"+ (i+1).ToString());
                writer.WriteStartElement("data");
                writer.WriteAttributeString("", "key", "", "label");
                writer.WriteString((i+1).ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

        }
        private void write_edges(XmlTextWriter writer,List<Node> nodes)
        {
            int p = 1;
            for (int i = 0; i < nodes.Count(); i++)
            {
                if (nodes[i].GetEdges() != null)
                {
                    for (int j = 0; j < nodes[i].GetEdges().Count(); j++)
                    {
                        writer.WriteStartElement("edge");
                        writer.WriteAttributeString("", "id", "", "e" + (p).ToString());
                        writer.WriteAttributeString("", "source", "", "n" + (i + 1).ToString());
                        writer.WriteAttributeString("", "target", "", "n" + (nodes[i].GetEdges()[j] + 1).ToString());
                        writer.WriteEndElement();
                        p++;
                    }
                }
            }

        }
        public void make_XML_file(String name, Graph graf)
        {
            XmlTextWriter writer = new XmlTextWriter(name + ".xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.WriteStartElement("graphml");
            writer.WriteAttributeString("x", "xmlns", "", "http://graphml.graphdrawing.org/xmlns");
            writer.WriteAttributeString("x", "xmlns:xsi", "", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("x", "xsi:schemaLocation", "", "http://graphml.graphdrawing.org/xmlns http://graphml.graphdrawing.org/xmlns/1.0/graphml.xsd");
            writer.WriteStartElement("key");
            writer.WriteAttributeString("", "id", "", "label");
            writer.WriteAttributeString("", "for", "", "node");
            writer.WriteAttributeString("", "attr.name", "", "label");
            writer.WriteAttributeString("", "attr.type", "", "string");
            writer.WriteEndElement();
            writer.WriteStartElement("graph");
            writer.WriteAttributeString("x", "edegedefault", "", "undirected");
            write_nodes(writer, graf.GetNodes());
            write_edges(writer, graf.GetNodes());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

        }
       
    }
}
