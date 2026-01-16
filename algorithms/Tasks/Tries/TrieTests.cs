namespace Tasks.Tries;

public class TrieTests
{
    [Fact]
    public void Search_NotExists_ShouldBeOk( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {'a', new TrieNode<int>( 'a', 1 )},
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Exists( "word" );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Search_NotEnd_ShouldBeOk( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'w', 
                    new TrieNode<int>( 'w', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'o', 
                                new TrieNode<int>( 'o', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                Children = new Dictionary<char, TrieNode<int>>
                                                {
                                                    {
                                                        'd', 
                                                        new TrieNode<int>( 'd', 1 )
                                                        {
                                                            Children = new Dictionary<char, TrieNode<int>>
                                                            {
                                                                {
                                                                    'e', new TrieNode<int>( 'e', 1 )
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Exists( "word" );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Search_HasEnd_ShouldBeOk( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'w', 
                    new TrieNode<int>( 'w', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'o', 
                                new TrieNode<int>( 'o', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                Children = new Dictionary<char, TrieNode<int>>
                                                {
                                                    {
                                                        'd', 
                                                        new TrieNode<int>( 'd', 1 )
                                                        {
                                                            IsEnd = true
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Exists( "word" );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Delete_HasWord_ShouldBeOk( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'w', 
                    new TrieNode<int>( 'w', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'o', 
                                new TrieNode<int>( 'o', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                Children = new Dictionary<char, TrieNode<int>>
                                                {
                                                    {
                                                        'd', 
                                                        new TrieNode<int>( 'd', 1 )
                                                        {
                                                            IsEnd = true
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Delete( "word" );

        // Assert
        Assert.True( res );
        Assert.False( trie.Exists( "word" ) );
    }
    
    [Fact]
    public void Delete_HasSingleCharWord_ShouldBeOk( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {'d', new TrieNode<int>( 'd', 1 )
                {
                    IsEnd = true
                } },
                {'b', new TrieNode<int>( 'b', 1 )
                {
                    IsEnd = true
                }}
            }
        } );

        // Act
        var res = trie.Delete( "d" );

        // Assert
        Assert.True( res );
        Assert.False( trie.Exists( "d" ) );
    }
    
    [Fact]
    public void Delete_HasTwoEndWords_ShouldBeTrue( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'w', 
                    new TrieNode<int>( 'w', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'o', 
                                new TrieNode<int>( 'o', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                Children = new Dictionary<char, TrieNode<int>>
                                                {
                                                    {
                                                        'd', 
                                                        new TrieNode<int>( 'd', 1 )
                                                        {
                                                            IsEnd = true,
                                                            Children = new Dictionary<char, TrieNode<int>>
                                                            {
                                                                {
                                                                    'c',
                                                                    new TrieNode<int>( 'c', 1 )
                                                                    {
                                                                        IsEnd = true
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Delete( "word" );

        // Assert
        Assert.True( res );
        Assert.False( trie.Exists( "word" ) );
    }
    
    [Fact]
    public void Delete_HasTwoEndWords_ShouldNotBeDeleted( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'w', 
                    new TrieNode<int>( 'w', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'o', 
                                new TrieNode<int>( 'o', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                Children = new Dictionary<char, TrieNode<int>>
                                                {
                                                    {
                                                        'd', 
                                                        new TrieNode<int>( 'd', 1 )
                                                        {
                                                            IsEnd = false,
                                                            Children = new Dictionary<char, TrieNode<int>>
                                                            {
                                                                {
                                                                    'c',
                                                                    new TrieNode<int>( 'c', 1 )
                                                                    {
                                                                        IsEnd = true
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Delete( "word" );

        // Assert
        Assert.False( res );
        Assert.False( trie.Exists( "word" ) );
    }
    
    [Fact]
    public void Delete_HasTwoEndSimilarLengthWords_ShouldBeTrue( )
    {
        // Arrange
        Trie<int> trie = new Trie<int>( new TrieNode<int>( '-', 0 )
        {
            Children = new Dictionary<char, TrieNode<int>>
            {
                {
                    'c', 
                    new TrieNode<int>( 'c', 1 )
                    {
                        Children = new Dictionary<char, TrieNode<int>>()
                        {
                            {
                                'a', 
                                new TrieNode<int>( 'a', 1 )
                                {
                                    Children = new Dictionary<char, TrieNode<int>>
                                    {
                                        {
                                            'r', 
                                            new TrieNode<int>( 'r', 1 )
                                            {
                                                IsEnd = true
                                            }
                                        },
                                        {
                                            'm', 
                                            new TrieNode<int>( 'm', 1 )
                                            {
                                                IsEnd = true
                                            }
                                        }
                                    }
                                }
                            },
                        }
                    }
                    
                },
                {'b', new TrieNode<int>( 'b', 1 )}
            }
        } );

        // Act
        var res = trie.Delete( "car" );

        // Assert
        Assert.True( res );
        Assert.False( trie.Exists( "car" ) );
    }
}