﻿using NPOI.OpenXml4Net.Util;
using NPOI.OpenXmlFormats.Dml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NPOI.OpenXmlFormats.Dml.Spreadsheet
{
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing")]
    public class CT_Shape // empty interface: EG_ObjectChoices
    {
        private CT_ShapeNonVisual nvSpPrField;
        private CT_ShapeProperties spPrField;
        private CT_ShapeStyle styleField;
        private CT_TextBody txBodyField;

        private string macroField;
        private string textlinkField;
        private bool fLocksTextField;
        private bool fPublishedField;

        public void Set(CT_Shape obj)
        {
            this.macroField = obj.macro;
            this.textlinkField = obj.textlink;
            this.fLocksTextField = obj.fLocksText;
            this.fPublishedField = obj.fPublished;

            this.nvSpPrField = obj.nvSpPr;
            this.spPrField = obj.spPr;
            this.styleField = obj.style;
            this.txBodyField = obj.txBody;
        }

        public static CT_Shape Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_Shape ctShape = new CT_Shape();
            if (node.Attributes["macro"] != null)
                ctShape.macroField = node.Attributes["macro"].Value;
            if (node.Attributes["textlink"] != null)
                ctShape.textlinkField = node.Attributes["textlink"].Value;
            ctShape.fLocksTextField = XmlHelper.ReadBool(node.Attributes["fLocksText"]);
            ctShape.fPublishedField = XmlHelper.ReadBool(node.Attributes["fPublished"]);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "nvPicPr")
                {
                    ctShape.nvSpPr = CT_ShapeNonVisual.Parse(childNode, namespaceManager);
                }
                else if (childNode.LocalName == "spPr")
                {
                    ctShape.spPr = CT_ShapeProperties.Parse(childNode, namespaceManager);
                }
                //else if (childNode.LocalName == "style")
                //{
                //    throw new NotImplementedException();
                //}
                //else if (childNode.LocalName == "txBody")
                //{
                //    throw new NotImplementedException();
                //}
            }
            return ctShape;
        }

        public CT_ShapeNonVisual AddNewNvSpPr()
        {
            this.nvSpPrField = new CT_ShapeNonVisual();
            return this.nvSpPrField;
        }

        public CT_ShapeProperties AddNewSpPr()
        {
            this.spPrField = new CT_ShapeProperties();
            return this.spPrField;
        }
        public CT_ShapeStyle AddNewStyle()
        {
            this.styleField = new CT_ShapeStyle();
            return this.styleField;
        }
        public CT_TextBody AddNewTxBody()
        {
            this.txBodyField = new CT_TextBody();
            return this.txBodyField;
        }

        public CT_ShapeNonVisual nvSpPr
        {
            get
            {
                return this.nvSpPrField;
            }
            set
            {
                this.nvSpPrField = value;
            }
        }
        public CT_ShapeProperties spPr
        {
            get
            {
                return this.spPrField;
            }
            set
            {
                this.spPrField = value;
            }
        }
        public CT_TextBody txBody
        {
            get
            {
                return this.txBodyField;
            }
            set
            {
                this.txBodyField = value;
            }
        }
        public CT_ShapeStyle style
        {
            get
            {
                return this.styleField;
            }
            set
            {
                this.styleField = value;
            }
        }

        [XmlAttribute]
        public string macro
        {
            get { return macroField; }
            set { macroField = value; }
        }

        [XmlAttribute]
        public string textlink
        {
            get { return textlinkField; }
            set { textlinkField = value; }
        }
        [XmlAttribute]
        public bool fLocksText
        {
            get { return fLocksTextField; }
            set { fLocksTextField = value; }
        }

        [XmlAttribute]
        public bool fPublished
        {
            get { return fPublishedField; }
            set { fPublishedField = value; }
        }

        internal void Write(StreamWriter sw)
        {
            sw.Write("<xdr:sp");
            if (this.macroField != null)
            {
                sw.Write(string.Format(" macro=\"{0}\"", this.macroField));
            }
            if (this.textlinkField != null)
            {
                sw.Write(string.Format(" textlink=\"{0}\"", this.textlinkField));
            }
            if (this.fLocksTextField)
            {
                sw.Write(" fLocksText=\"1\"");
            }
            if (this.fPublishedField)
            {
                sw.Write(" fPublished=\"1\"");
            }
            sw.Write(">");
            if (this.nvSpPr != null)
            {
                this.nvSpPr.Write(sw, "nvSpPr");
            }
            if (this.spPr != null)
            {
                this.spPr.Write(sw, "spPr");
            }
            sw.Write("</xdr:sp>");
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing")]
    public class CT_ShapeNonVisual
    {
        private CT_NonVisualDrawingProps cNvPrField;
        private CT_NonVisualDrawingShapeProps cNvSpPrField;

        public CT_NonVisualDrawingProps AddNewCNvPr()
        {
            this.cNvPrField = new CT_NonVisualDrawingProps();
            return this.cNvPrField;
        }
        public CT_NonVisualDrawingShapeProps AddNewCNvSpPr()
        {
            this.cNvSpPrField = new CT_NonVisualDrawingShapeProps();
            return this.cNvSpPrField;
        }
        public CT_NonVisualDrawingProps cNvPr
        {
            get
            {
                return this.cNvPrField;
            }
            set
            {
                this.cNvPrField = value;
            }
        }

        public CT_NonVisualDrawingShapeProps cNvSpPr
        {
            get
            {
                return this.cNvSpPrField;
            }
            set
            {
                this.cNvSpPrField = value;
            }
        }
        public static CT_ShapeNonVisual Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_ShapeNonVisual ctObj = new CT_ShapeNonVisual();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "cNvPr")
                    ctObj.cNvPr = CT_NonVisualDrawingProps.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "cNvSpPr")
                    ctObj.cNvSpPr = CT_NonVisualDrawingShapeProps.Parse(childNode, namespaceManager);
            }
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<xdr:{0}", nodeName));
            sw.Write(">");
            if (this.cNvPr != null)
                this.cNvPr.Write(sw, "cNvPr");
            if (this.cNvSpPr != null)
                this.cNvSpPr.Write(sw, "cNvSpPr");
            sw.Write(string.Format("</xdr:{0}>", nodeName));
        }


    }

    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing")]
    public class CT_GroupShape
    {
        CT_GroupShapeProperties grpSpPrField;
        CT_GroupShapeNonVisual nvGrpSpPrField;
        CT_Connector connectorField = null;
        CT_Picture pictureField = null;
        CT_Shape shapeField = null;

        public void Set(CT_GroupShape groupShape)
        {
            this.grpSpPrField = groupShape.grpSpPr;
            this.nvGrpSpPrField = groupShape.nvGrpSpPr;
        }

        public CT_GroupShapeProperties AddNewGrpSpPr()
        {
            this.grpSpPrField = new CT_GroupShapeProperties();
            return this.grpSpPrField;
        }
        public CT_GroupShapeNonVisual AddNewNvGrpSpPr()
        {
            this.nvGrpSpPrField = new CT_GroupShapeNonVisual();
            return this.nvGrpSpPrField;
        }
        public CT_Connector AddNewCxnSp()
        {
            connectorField = new CT_Connector();
            return connectorField;
        }
        public CT_Shape AddNewSp()
        {
            shapeField = new CT_Shape();
            return shapeField;
        }
        public CT_Picture AddNewPic()
        {
            pictureField = new CT_Picture();
            return pictureField;
        }

        public CT_GroupShapeNonVisual nvGrpSpPr
        {
            get { return nvGrpSpPrField; }
            set { nvGrpSpPrField = value; }
        }
        public CT_GroupShapeProperties grpSpPr
        {
            get { return grpSpPrField; }
            set { grpSpPrField = value; }

        }

        internal void Write(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        internal static CT_GroupShape Parse(XmlNode xmlNode, XmlNamespaceManager namespaceManager)
        {
            if (xmlNode == null)
                return null;

            throw new NotImplementedException();
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing")]
    public class CT_GroupShapeNonVisual
    {
        CT_NonVisualDrawingProps cNvPrField;
        CT_NonVisualGroupDrawingShapeProps cNvGrpSpPrField;

        public CT_NonVisualGroupDrawingShapeProps AddNewCNvGrpSpPr()
        {
            this.cNvGrpSpPrField = new CT_NonVisualGroupDrawingShapeProps();
            return this.cNvGrpSpPrField;
        }
        public CT_NonVisualDrawingProps AddNewCNvPr()
        {
            this.cNvPrField = new CT_NonVisualDrawingProps();
            return this.cNvPrField;
        }

        public CT_NonVisualDrawingProps cNvPr
        {
            get { return cNvPrField; }
            set { cNvPrField = value; }
        }
        public CT_NonVisualGroupDrawingShapeProps cNvGrpSpPr
        {
            get { return cNvGrpSpPrField; }
            set { cNvGrpSpPrField = value; }
        }
    }

}
