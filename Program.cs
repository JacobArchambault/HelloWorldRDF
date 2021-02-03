﻿using System;
using VDS.RDF;
using VDS.RDF.Writing;

namespace HelloWorldRDF
{
    public class HelloWorld
    {
        public static void Main()
        {
            //Fill in the code shown on this page here to build your hello world application
            Graph g = new();

            IUriNode dotNetRDF = g.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            IUriNode says = g.CreateUriNode(UriFactory.Create("http://example.org/says"));
            ILiteralNode helloWorld = g.CreateLiteralNode("Hello World");
            ILiteralNode bonjourMonde = g.CreateLiteralNode("Bonjour tout le Monde", "fr");

            g.Assert(new Triple(dotNetRDF, says, helloWorld));
            g.Assert(new Triple(dotNetRDF, says, bonjourMonde));

            foreach (Triple t in g.Triples)
            {
                Console.WriteLine(t.ToString());
            }

            NTriplesWriter ntwriter = new();
            ntwriter.Save(g, "HelloWorld.nt");

            RdfXmlWriter rdfxmlwriter = new();
            rdfxmlwriter.Save(g, "HelloWorld.rdf");
        }
    }
}