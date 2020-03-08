namespace ProductsImport.Tests
{
    class TestConstants
    {
        public const string JsonFileText = @"{
                              'products': [
                                            {
                                              'categories': [
                                                'Customer Service',
                                                'Call Center'
                                              ],
                                              'twitter': '@freshdesk',
                                              'title': 'Freshdesk'
                                            },
                                            {
                                              'categories': [
                                                'CRM',
                                                'Sales Management'
                                              ],
                                              'title': 'Zoho'
                                            }
                                          ]
                                        }";

        public const string YamlFileText = @"---
                                    -
                                      tags: 'Bugs & Issue Tracking, Development Tools'
                                      name: 'GitGHub'
                                      twitter: 'github'
                                    -
                                      tags: 'Instant Messaging & Chat,Web Collaboration,Productivity'
                                      name: 'Slack'
                                      twitter: 'slackhq'
                                    -
                                      tags: 'Project Management,Project Collaboration,Development Tools'
                                      name: 'JIRA Software'
                                      twitter: 'jira'
                                    ";
    }
}
