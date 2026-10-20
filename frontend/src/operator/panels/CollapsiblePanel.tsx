import { useState, useRef, useEffect } from 'react';

interface CollapsibleProps {
    title: string;
    children: React.ReactNode;
}

export function CollapsiblePanel({ title, children }: CollapsibleProps) {
    const [isOpen, setIsOpen] = useState(false);
    const [height, setHeight] = useState('0px');
    const contentRef = useRef<HTMLDivElement>(null);

    useEffect(() => {
        if (contentRef.current){
            setHeight(isOpen ? `${contentRef.current.scrollHeight}px` : '0px');
        }
    }, [isOpen]);

    return (
        <div style={{ border: '1px solid #ccc', borderRadius: '4px', margin: '10px 0'}}>
            <button onClick={() => setIsOpen(!isOpen)} 
                style={{ width: '100%', padding: '12px', textAlign: 'left', 
                cursor: 'pointer', background: '#f5f5f5', border: 'none', display: 'flex', justifyContent: 'space-between', 
                alignItems: 'center' }}
            >
                <span>{title}</span> <span>{isOpen ? 'Retract' : 'Expand' }</span>
            </button>
            <div
                ref={contentRef}
                style={{ maxHeight: height, overflow: 'hidden', transition: 'max-height 0.2s ease-out' }}
            >
                <div style= {{ padding: '15px' }}>
                    {children}
                </div>
            </div>
        </div>
    );
}